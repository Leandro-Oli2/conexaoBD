using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace exercicio
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Usuario());
        }
         public class Usuario : Form
        {
            private Label label1, label2, label3, label4, label5;
            private TextBox txtId, txtNome, txtSenha, txtRamal, txtEspec;
            private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
            private ListBox lstUsuarios;
            private Crud crud;

            private TabControl tabControl;
            private TabPage tabPage1, tabPage2; 

            public Usuario()
            {
                crud = new Crud();
                this.Size = new Size(500, 500);
                this.Text = "Cadastro de Usuários";
                this.BackColor = Color.White;

                Font fonte = new Font("Arial", 12, FontStyle.Bold);
                Font fonteAlternativa = new Font("Arial", 12, FontStyle.Italic);

                label1 = new Label { Text = "ID:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.Blue };
                label2 = new Label { Text = "Senha:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.Blue };
                label3 = new Label { Text = "Nome:", Location = new Point(20, 160), Font = fonte, ForeColor = Color.Blue };
                label4 = new Label { Text = "Ramal:", Location = new Point(20, 210), Font = fonte, ForeColor = Color.Blue };
                label5 = new Label { Text = "Especialidade:", Location = new Point(20, 260), Font = fonte, ForeColor = Color.Blue };

                txtId = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonteAlternativa };
                txtSenha = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonteAlternativa };
                txtNome = new TextBox { Location = new Point(20, 180), Width = 220, Font = fonteAlternativa };
                txtRamal = new TextBox { Location = new Point(20, 230), Width = 220, Font = fonteAlternativa };
                txtEspec = new TextBox { Location = new Point(20, 280), Width = 220, Font = fonteAlternativa };
                

                // Criando botões corretamente
                btnInserir = CriarBotao("Inserir", new Point(270, 80), Color.LightGreen);
                btnListar = CriarBotao("Listar", new Point(270, 130), Color.LightBlue);
                btnAtualizar = CriarBotao("Atualizar", new Point(270, 180), Color.Orange);
                btnDeletar = CriarBotao("Deletar", new Point(270, 230), Color.Red);

                // Associando eventos de clique aos botões
                btnInserir.Click += ButtonInserir_Click;
                btnListar.Click += ButtonListar_Click;
                btnAtualizar.Click += ButtonAtualizar_Click;
                // btnDeletar.Click += ButtonDeletar_Click;

                tabControl = new TabControl { Location = new Point(10, 10), Width = 400, Height = 30 };  // Ajustando o tamanho

                // Criando as abas
                tabPage1 = new TabPage { Text = "Maquinas" };
                tabPage2 = new TabPage { Text = "Software" };

                // Adicionando os painéis às abas
                tabPage1.Controls.Add(new Maquina());
                tabPage2.Controls.Add(new Software());

                // Adicionando as abas ao controle de abas
                tabControl.TabPages.Add(tabPage1);
                tabControl.TabPages.Add(tabPage2);

                // Adicionando o controle de abas ao formulário
                this.Controls.Add(tabControl);

                lstUsuarios = new ListBox
                {
                    Location = new Point(20, 310),
                    Width = 440,
                    Height = 150,
                    BackColor = Color.White,
                    ForeColor = Color.Blue,
                };

                // Adicionando os elementos ao formulário
                this.Controls.Add(label1);
                this.Controls.Add(label2);
                this.Controls.Add(label3);
                this.Controls.Add(label4);
                this.Controls.Add(label5);
                this.Controls.Add(txtId);
                this.Controls.Add(txtNome);
                this.Controls.Add(txtSenha);
                this.Controls.Add(txtRamal);
                this.Controls.Add(txtEspec);
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
                    if(!int.TryParse(txtId.Text, out int id)){
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
                    if(!int.TryParse(txtRamal.Text, out int ramal)){
                        MessageBox.Show("RAMAL deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
                    string senha = txtSenha.Text;
                    string nome = txtNome.Text;
                    string espec = txtEspec.Text;

                    crud.InserirUsuario(id, senha, nome, ramal, espec);
                    MessageBox.Show("Usuario Inserido Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // LimparCampos();

                }catch(Exception ex){
                    MessageBox.Show("Erro ao Inserir Usuario: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            private void ButtonListar_Click(object sender, EventArgs e)
            {
            try{
                var clientes = crud.ListarUsuarios();
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
        public class Maquina : Panel
    {
        public Maquina()
        {
            this.BackColor = Color.LightBlue;
            this.Size = new Size(300, 300);

            Label label = new Label { Text = "Tela 1" };
            label.Location = new Point(100, 100);
            this.Controls.Add(label);
        }
    }

    public class Software : Panel
    {
        public Software()
        {
            this.BackColor = Color.LightGreen;
            this.Size = new Size(300, 300);

            Label label = new Label { Text = "Tela 2" };
            label.Location = new Point(100, 100);
            this.Controls.Add(label);
        }
    }
    }
}