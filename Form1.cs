namespace NameClassify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            string name = txtFullname.Text.ToString();

            PersonName p = new PersonName();
            p.splitName(name);

            txtTitle.Text = p.title;
            txtFname.Text = p.firstName;
            txtLname.Text = p.lastName;
        }

        private void btnCase1_Click(object sender, EventArgs e)
        {
            txtFullname.Text = "นาย เอกสิทธิ์ ศรีสุข";
        }

        private void btnCase2_Click(object sender, EventArgs e)
        {
            txtFullname.Text = "ดร.เอกสิทธิ์ ศรีสุข";
        }

        private void btnCase3_Click(object sender, EventArgs e)
        {
            txtFullname.Text = "ดร.เอกสิทธิ์ ณ อุดรธานี";
        }
    }
}