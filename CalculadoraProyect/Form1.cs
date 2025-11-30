namespace CalculadoraProyect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

   
        private void NumberButton_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
              

            txtPantalla.Text += btn.Text; 
        }

        private void caracterButton_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            txtPantalla.Text += btn.Text;
            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);

        }

        private void btnPder_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);

        }

        private void txtPantalla_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtPantalla.Text)) // Check for null or empty string
            {
                txtPantalla.Text = txtPantalla.Text.Substring(0, txtPantalla.Text.Length - 1);
            }

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
    {
        stringConversion strCon = new stringConversion();
        var expr = txtPantalla.Text ?? string.Empty;
        var result = strCon.EvaluarExpresion(expr);
        txtPantalla.Text = result.ToString() ?? string.Empty;
    }
    catch (FormatException fex)
    {
        MessageBox.Show("Expresión inválida: " + fex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al evaluar la expresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtPantalla.Clear();
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btnPizq_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnEntre_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnPor_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            caracterButton_Click(sender, e);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            NumberButton_Click(sender, e);
        }
    }
}
