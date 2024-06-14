using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

public class CheckBoxComboBox : ComboBox
{
    public CheckBoxComboBox()
    {
        this.DrawMode = DrawMode.OwnerDrawFixed;
        this.DropDownHeight = 1;
        this.CheckBoxItems = new List<CheckBoxComboBoxItem>();
    }

    public List<CheckBoxComboBoxItem> CheckBoxItems { get; set; }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0) return;

        CheckBoxComboBoxItem item = CheckBoxItems[e.Index];
        e.DrawBackground();

        CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.X, e.Bounds.Y),
            item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);

        e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds.X + 20, e.Bounds.Y);
        e.DrawFocusRectangle();
    }

    protected override void OnDropDownClosed(EventArgs e)
    {
        string selectedItems = string.Join(", ", CheckBoxItems.Where(i => i.Checked).Select(i => i.Text));
        this.Text = selectedItems;
        base.OnDropDownClosed(e);
    }

    protected override void OnDropDown(EventArgs e)
    {
        if (this.CheckBoxItems.Count > 0)
        {
            this.DropDownHeight = this.CheckBoxItems.Count * ItemHeight + 2;
        }
        base.OnDropDown(e);
    }

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        if (SelectedIndex >= 0)
        {
            CheckBoxItems[SelectedIndex].Checked = !CheckBoxItems[SelectedIndex].Checked;
            this.Invalidate();
        }
    }
}

public class CheckBoxComboBoxItem
{
    public string Text { get; set; }
    public bool Checked { get; set; }
}
