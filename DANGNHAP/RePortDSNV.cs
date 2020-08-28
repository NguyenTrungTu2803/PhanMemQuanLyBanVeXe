using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANGNHAP
{
    public partial class RePortDSNV : Form
    {
        public RePortDSNV()
        {
            InitializeComponent();
        }

        private void RePortDSNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcountDataSet.ACCOUNTDAILY' table. You can move, or remove it, as needed.
            this.ACCOUNTDAILYTableAdapter.Fill(this.AcountDataSet.ACCOUNTDAILY);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
