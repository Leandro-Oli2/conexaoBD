using System;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo3_ADO_FORMS
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cadastro());
        }
    }

    public class Cadastro : Form
    {
        private Label label1, label2, label3;
        private TextBox txtId, txtNome, txtEmail;
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
        private ListBox lstUsuarios;
        private CRUD crud;

        public Cadastro()
        {
            crud = new CRUD();
            this.Size = new Size(500, 500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.White;

            Font fonte = new Font("Arial", 12, FontStyle.Bold);
            Font fonteAlternativa = new Font("Arial", 12, FontStyle.Italic);

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.Blue };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.Blue };
            label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.Blue };

            txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonteAlternativa };
            txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonteAlternativa };
            txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonteAlternativa };

            // Criando botões corretamente
            btnInserir = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btnListar = CriarBotao("Listar", new Point(270, 80), Color.LightBlue);
            btnAtualizar = CriarBotao("Atualizar", new Point(270, 130), Color.Orange);
            btnDeletar = CriarBotao("Deletar", new Point(270, 180), Color.Red);

            // Associando eventos de clique aos botões
            btnInserir.Click += ButtonInserir_Click;
            btnListar.Click += ButtonListar_Click;
            btnAtualizar.Click += ButtonAtualizar_Click;
            btnDeletar.Click += ButtonDeletar_Click;

            lstUsuarios = new ListBox
            {
                Location = new Point(20, 230),
                Width = 440,
                Height = 150,
                BackColor = Color.White,
                ForeColor = Color.Blue,
            };

            // Adicionando os elementos ao formulário
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(lstUsuarios);
        }

        // Método para criar botões reutilizáveis
        private Button CriarBotao(string texto, Point localizacao, Color corFundo)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = corFundo,
                ForeColor = Color.Black
            };
        }

        // Métodos que serão chamados ao clicar nos botões
        private void ButtonInserir_Click(object sender, EventArgs e)
        {
            try{
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuario Inserido Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // LimparCampos();

            }catch(Exception ex){
                MessageBox.Show("Erro ao Inserir Usuario: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ButtonListar_Click(object sender, EventArgs e)
        {
           try{
            var clientes = crud.ListarClientes();
            lstUsuarios.Items.Clear();
            foreach(var cliente in clientes){
                lstUsuarios.Items.Add(cliente);
            }
            MessageBox.Show("Listagem Feita com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);         
           }catch(Exception ex){
                MessageBox.Show("Erro ao Listar Usuario: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try{
                if(!int.TryParse(txtId.Text, out int id)){
                    MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuario Atualizado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // LimparCampos();

            }catch(Exception ex){
                MessageBox.Show("Erro ao Atualizr o Usuario: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeletar_Click(object sender, EventArgs e)
        {
            try{
                if(!int.TryParse(txtId.Text, out int id)){
                    MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuario Deletado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // LimparCampos();

            }catch(Exception ex){
                MessageBox.Show("Erro ao Deletar o Usuario: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
