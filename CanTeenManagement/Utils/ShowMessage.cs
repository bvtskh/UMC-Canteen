using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement.Utils
{
    public class ShowMessage
    {
        public ShowMessage(string content, string header, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(content, header, button, icon);
        }
    }
}
