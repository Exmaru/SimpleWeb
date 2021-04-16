using System.Windows.Forms;

namespace WEC_Builder.Models
{
    public partial class ApiTestParameters : UserControl
    {
        public ApiTestParameters()
        {
            InitializeComponent();
        }

        public string ID
        {
            get
            {
                return TB_ID.Text;
            }
            set
            {
                TB_ID.Text = value;
            }
        }

        public string Value
        {
            get
            {
                return TB_Value.Text;
            }
            set
            {
                TB_Value.Text = value;
            }
        }
    }
}
