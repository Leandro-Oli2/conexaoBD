namespace Exemplo1_Winforms_IDE;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e){
        int num = 0;
        int num2 = 0;
        int soma = 0;
        try{
            num = Convert.ToInt32(textBox1.Text);
            num2 = Convert.ToInt32(textBox2.Text);
            MessageBox.Show("A soma dos numeros é: "+ (num + num2) + "\nA subtração dos numeros é: "+ (num - num2) + "\nA multiplicato dos numeros é: "+ (num * num2) + "\nA divisao dos números é: "+ (num / num2));
        }
        catch (FormatException ex){
            MessageBox.Show("Por favor, insira valores numéricos.");
        }
    }
}
