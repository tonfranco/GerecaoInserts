using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Business
{
    public class clMessage
    {
        public enum MessageType
        {
            Error = 1,
            Information = 2,
            Exclamation = 3
        }

        public void msgBox(string message, string title, MessageType messageType)
        {
            try
            {
                switch (messageType)
                {
                    case MessageType.Error:
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MessageType.Information:
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case MessageType.Exclamation:
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
