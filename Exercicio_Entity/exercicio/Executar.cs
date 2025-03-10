using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace exercicio
{
    public class Executar
    {
        //dotnet publish -r win-x64 -c Release --self-contained true
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
    private TabPage tabPage0, tabPage1, tabPage2; 

    public Usuario()
    {
        crud = new Crud();
        this.Icon = new Icon();
        this.Size = new Size(500, 500);
        this.Text = "Cadastro de Usuários";
        this.BackColor = Color.White;

        Font fonte = new Font("Arial", 12, FontStyle.Bold);
        Font fonteAlternativa = new Font("Arial", 12, FontStyle.Italic);

        
        label1 = new Label { Text = "ID:", Font = fonte, ForeColor = Color.Blue };
        label2 = new Label { Text = "Senha:", Font = fonte, ForeColor = Color.Blue };
        label3 = new Label { Text = "Nome:", Font = fonte, ForeColor = Color.Blue };
        label4 = new Label { Text = "Ramal:", Font = fonte, ForeColor = Color.Blue };
        label5 = new Label { Text = "Espec.:", Font = fonte, ForeColor = Color.Blue };

        txtId = new TextBox { Width = 220, Font = fonteAlternativa };
        txtSenha = new TextBox { Width = 220, Font = fonteAlternativa };
        txtNome = new TextBox { Width = 220, Font = fonteAlternativa };
        txtRamal = new TextBox { Width = 220, Font = fonteAlternativa };
        txtEspec = new TextBox { Width = 220, Font = fonteAlternativa };

       
        btnInserir = CriarBotao("Inserir", "https://img.icons8.com/ios-filled/50/000000/plus.png", Color.LightGreen);
            btnListar = CriarBotao("Listar", "https://img.icons8.com/ios-filled/50/000000/list.png", Color.LightBlue);
            btnAtualizar = CriarBotao("Atualizar", "https://img.icons8.com/ios-filled/50/000000/edit.png", Color.Orange);
            btnDeletar = CriarBotao("Deletar", "https://img.icons8.com/ios-filled/50/000000/trash.png", Color.Red);

        
        btnInserir.Click += ButtonInserir_Click;
        btnListar.Click += ButtonListar_Click;
        btnAtualizar.Click += ButtonAtualizar_Click;
        btnDeletar.Click += ButtonDeletar_Click;

        
        tabControl = new TabControl { Dock = DockStyle.Fill };

       
        tabPage0 = new TabPage { Text = "Usuário" };
        tabPage1 = new TabPage { Text = "Máquinas" };
        tabPage2 = new TabPage { Text = "Software" };

        
        tabPage0.Controls.Add(label1);
        tabPage0.Controls.Add(label2);
        tabPage0.Controls.Add(label3);
        tabPage0.Controls.Add(label4);
        tabPage0.Controls.Add(label5);
        tabPage0.Controls.Add(txtId);
        tabPage0.Controls.Add(txtNome);
        tabPage0.Controls.Add(txtSenha);
        tabPage0.Controls.Add(txtRamal);
        tabPage0.Controls.Add(txtEspec);
        tabPage0.Controls.Add(btnInserir);
        tabPage0.Controls.Add(btnListar);
        tabPage0.Controls.Add(btnAtualizar);
        tabPage0.Controls.Add(btnDeletar);

        
        lstUsuarios = new ListBox
        {
            BackColor = Color.White,
            ForeColor = Color.Blue,
        };
        tabPage0.Controls.Add(lstUsuarios); 
        tabPage1.Controls.Add(new Maquina());
        tabPage2.Controls.Add(new Software());

        
        tabControl.TabPages.Add(tabPage0);
        tabControl.TabPages.Add(tabPage1);
        tabControl.TabPages.Add(tabPage2);

    
        this.Controls.Add(tabControl);

        
        this.Resize += Usuario_Resize;

       
        AjustarLayout();
    }


    private Button CriarBotao(string texto, string urlImagem, Color corFundo)
    {
        Button botao = new Button
        {
            Text = texto,
            Width = 100,
            Height = 30,
            BackColor = corFundo,
            ForeColor = Color.Black,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            ImageAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(5, 0, 5, 0),
        };

        try
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] imagemBytes = webClient.DownloadData(urlImagem);
                using (var ms = new System.IO.MemoryStream(imagemBytes))
                {
                    botao.Image = Image.FromStream(ms);
                    botao.Image = new Bitmap(botao.Image, new Size(30, 30));
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return botao;
    }

   
    private void AjustarLayout()
    {
        int padding = 20;
        int labelWidth = 100;
        int textBoxWidth = 220;
        int buttonWidth = 100;

        label1.Location = new Point(padding, padding);
        txtId.Location = new Point(padding, padding + 20);

        label2.Location = new Point(padding, padding + 60);
        txtSenha.Location = new Point(padding, padding + 80);

        label3.Location = new Point(padding, padding + 100);
        txtNome.Location = new Point(padding, padding + 120);

        label4.Location = new Point(padding, padding + 140);
        txtRamal.Location = new Point(padding, padding + 160);

        label5.Location = new Point(padding, padding + 180);
        txtEspec.Location = new Point(padding, padding + 200);

       
        btnInserir.Location = new Point(padding + textBoxWidth + 20, padding);
        btnListar.Location = new Point(padding + textBoxWidth + 20, padding + 60);
        btnAtualizar.Location = new Point(padding + textBoxWidth + 20, padding + 120);
        btnDeletar.Location = new Point(padding + textBoxWidth + 20, padding + 180);

       
        lstUsuarios.Location = new Point(padding, padding + 240);
        lstUsuarios.Width = tabPage0.ClientSize.Width - 40; 
        lstUsuarios.Height = tabPage0.ClientSize.Height - 300; 
    }

    private void Usuario_Resize(object sender, EventArgs e)
    {
        AjustarLayout();
    }

    
    private void ButtonInserir_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtRamal.Text, out int ramal))
            {
                MessageBox.Show("RAMAL deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string senha = txtSenha.Text;
            string nome = txtNome.Text;
            string espec = txtEspec.Text;

            crud.InserirUsuario(id, senha, nome, ramal, espec);
            MessageBox.Show("Usuário Inserido Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao Inserir Usuário: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonListar_Click(object sender, EventArgs e)
    {
        try
        {
            var clientes = crud.ListarUsuarios();
            lstUsuarios.Items.Clear();
            foreach (var cliente in clientes)
            {
                lstUsuarios.Items.Add(cliente);
            }
            MessageBox.Show("Listagem Feita com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao Listar Usuário: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nome = txtNome.Text;

            crud.AtualizarUsuario(id, nome);
            MessageBox.Show("Usuário Atualizado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao Atualizar o Usuário: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonDeletar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            crud.DeletarUsuario(id);
            MessageBox.Show("Usuário Deletado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao Deletar o Usuário: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
       public class Maquina : Panel
{
    private Label label1, label2, label3, label4, label5, label6, label7;
    private TextBox txtId, txtSenha, txtVelocidade, txtHardDisk, txtMemoria, txtfkuser, txtPlaca;
    private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
    private ListBox lstMaquinas;
    private Crud crud;

    public Maquina()
    {
                crud = new Crud();
                
                this.Size = new Size(500, 500);
                

                label1 = new Label { Text = "ID:", Location = new Point(20, 10) };
                label2 = new Label { Text = "Senha:", Location = new Point(20, 60) };
                label3 = new Label { Text = "Velocidade:", Location = new Point(20, 110) };
                label4 = new Label { Text = "Hard Disk:", Location = new Point(20, 160) };
                label5 = new Label { Text = "placa:", Location = new Point(20, 210) };
                label6 = new Label { Text = "Memória:", Location = new Point(20, 260) };
                label7 = new Label { Text = "fk-user:", Location = new Point(20, 310) };

                txtId = new TextBox { Location = new Point(20, 30), Width = 220 };
                txtSenha = new TextBox { Location = new Point(20, 80), Width = 220 };
                txtVelocidade = new TextBox { Location = new Point(20, 130), Width = 220 };
                txtHardDisk = new TextBox { Location = new Point(20, 180), Width = 220};
                txtPlaca = new TextBox {Location = new Point(20, 230), Width = 220};
                txtMemoria = new TextBox { Location = new Point(20, 280), Width = 220 };
                txtfkuser = new TextBox { Location = new Point(20, 330), Width = 220 };

                btnInserir = CriarBotao("Inserir", new Point(270, 40), Color.LightGreen);
                btnListar = CriarBotao("Listar", new Point(270, 90), Color.LightBlue);
                btnAtualizar = CriarBotao("Atualizar", new Point(270, 140), Color.Orange);
                btnDeletar = CriarBotao("Deletar", new Point(270, 190), Color.Red);

                btnInserir.Click += ButtonInserir_Click;
                btnListar.Click += ButtonListar_Click;
                btnAtualizar.Click += ButtonAtualizar_Click;
                btnDeletar.Click += ButtonDeletar_Click;

                lstMaquinas = new ListBox
                {
                    Location = new Point(20, 365),
                    Width = 410,
                    Height = 100,
                };

                this.Controls.Add(label1);
                this.Controls.Add(label2);
                this.Controls.Add(label3);
                this.Controls.Add(label4);
                this.Controls.Add(label5);
                this.Controls.Add(label6);
                this.Controls.Add(label7);
                this.Controls.Add(txtId);
                this.Controls.Add(txtSenha);
                this.Controls.Add(txtVelocidade);
                this.Controls.Add(txtHardDisk);
                this.Controls.Add(txtPlaca);
                this.Controls.Add(txtMemoria);
                this.Controls.Add(txtfkuser);
                this.Controls.Add(btnInserir);
                this.Controls.Add(btnListar);
                this.Controls.Add(btnAtualizar);
                this.Controls.Add(btnDeletar);
                this.Controls.Add(lstMaquinas);
            }

            private Button CriarBotao(string texto, Point localizacao, Color corFundo)
            {
                return new Button
                {
                    Text = texto,
                    Location = localizacao,
                    Width = 80,
                    Height = 30,
                    BackColor = corFundo,
                    ForeColor = Color.Black
                };
            }

           private void ButtonInserir_Click(object sender, EventArgs e)
            {
                try
                {
                    // Validações de entrada
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtVelocidade.Text, out int velocidade))
                    {
                        MessageBox.Show("Velocidade deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtHardDisk.Text, out int hardDisk))
                    {
                        MessageBox.Show("Hard Disk deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtMemoria.Text, out int memoria))
                    {
                        MessageBox.Show("Memória deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtPlaca.Text, out int placa))
                    {
                        MessageBox.Show("Placa deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtfkuser.Text, out int fkuser))
                    {
                        MessageBox.Show("fkuser deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string senha = txtSenha.Text;

                    crud.InserirMaquina(id, senha, velocidade, hardDisk, placa, memoria, fkuser); 
                    MessageBox.Show("Máquina Inserida Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateException dbEx)
                    {
                        MessageBox.Show("Erro ao Inserir Máquina: " + dbEx.InnerException?.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            private void ButtonListar_Click(object sender, EventArgs e)
            {
                try
                {
                    lstMaquinas.Items.Clear();
                    var maquinas = crud.ListarMaquina(); // Você precisa implementar esse método no Crud
                    foreach (var maquina in maquinas)
                    {
                        lstMaquinas.Items.Add(maquina);
                    }
                    MessageBox.Show("Listagem Feita com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Listar Máquinas: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ButtonAtualizar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtVelocidade.Text, out int novaVelocidade))
                    {
                        MessageBox.Show("Velocidade deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtHardDisk.Text, out int placa))
                    {
                        MessageBox.Show("Placa deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crud.AtualizarMaquina(id, novaVelocidade, placa);
                    MessageBox.Show("Máquina Atualizada Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Atualizar a Máquina: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ButtonDeletar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crud.DeletarMaquina(id);
                    MessageBox.Show("Máquina Deletada Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Deletar a Máquina: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            public class Software : Panel
        {
            private Label label1, label2, label3, label4, label5;
            private TextBox txtId, txtProduto, txtHardDisk, txtMemoria, txtfkMaquina;
            private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
            private ListBox lstSoftwares;
            private Crud crud;

            public Software()
        {
                crud = new Crud();
                this.BackColor = Color.LightGreen;
                this.Size = new Size(500, 500);

                label1 = new Label { Text = "ID:", Location = new Point(20, 10) };
                label2 = new Label { Text = "Produto:", Location = new Point(20, 60) };
                label3 = new Label { Text = "Hard Disk:", Location = new Point(20, 110) };
                label4 = new Label { Text = "Memória:", Location = new Point(20, 160) };
                label5 = new Label { Text = "fk-maq:", Location = new Point(20, 210) };


                txtId = new TextBox { Location = new Point(20, 35), Width = 220 };
                txtProduto = new TextBox { Location = new Point(20, 85), Width = 220 };
                txtHardDisk = new TextBox { Location = new Point(20, 135), Width = 220 };
                txtMemoria = new TextBox { Location = new Point(20, 185), Width = 220};
                txtfkMaquina = new TextBox { Location = new Point(20, 235), Width = 220};

                btnInserir = CriarBotao("Inserir",  new Point(270, 40), Color.LightGreen);
                btnListar = CriarBotao("Listar", new Point(270, 90), Color.LightBlue);
                btnAtualizar = CriarBotao("Atualizar",new Point(270, 140), Color.Orange);
                btnDeletar = CriarBotao("Deletar", new Point(270, 190), Color.Red);

                btnInserir.Click += ButtonInserir_Click;
                btnListar.Click += ButtonListar_Click;
                btnAtualizar.Click += ButtonAtualizar_Click;
                btnDeletar.Click += ButtonDeletar_Click;

                lstSoftwares = new ListBox
                {
                    Location = new Point(20, 260),
                    Width = 420,
                    Height = 100,
                };

                this.Controls.Add(label1);
                this.Controls.Add(label2);
                this.Controls.Add(label3);
                this.Controls.Add(label4);
                this.Controls.Add(label5);
                this.Controls.Add(txtId);
                this.Controls.Add(txtProduto);
                this.Controls.Add(txtHardDisk);
                this.Controls.Add(txtMemoria);
                this.Controls.Add(txtfkMaquina);
                this.Controls.Add(btnInserir);
                this.Controls.Add(btnListar);
                this.Controls.Add(btnAtualizar);
                this.Controls.Add(btnDeletar);
                this.Controls.Add(lstSoftwares);
            }

            private Button CriarBotao(string texto, Point localizacao, Color corFundo)
            {
                return new Button
                {
                    Text = texto,
                    Location = localizacao,
                    Width = 80,
                    Height = 30,
                    BackColor = corFundo,
                    ForeColor = Color.Black
                };
            }

            private void ButtonInserir_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtHardDisk.Text, out int hardDisk))
                    {
                        MessageBox.Show("Hard Disk deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtMemoria.Text, out int memoria))
                    {
                        MessageBox.Show("Memória deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtfkMaquina.Text, out int fkmaq))
                    {
                        MessageBox.Show("Memória deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string produto = txtProduto.Text;

                    crud.InserirSoftware(id, produto, hardDisk, memoria, fkmaq ); // Ajuste o FK conforme necessário
                    MessageBox.Show("Software Inserido Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateException dbEx)
                    {
                        MessageBox.Show("Erro ao Inserir Software: " + dbEx.InnerException?.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            private void ButtonListar_Click(object sender, EventArgs e)
            {
                try
                {
                    lstSoftwares.Items.Clear();
                    var softwares = crud.ListarSoftware(); // Você precisa implementar esse método no Crud
                    foreach (var software in softwares)
                    {
                        lstSoftwares.Items.Add(software);
                    }
                    MessageBox.Show("Listagem Feita com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Listar Softwares: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ButtonAtualizar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string novoProduto = txtProduto.Text;
                    if (!int.TryParse(txtHardDisk.Text, out int hardDisk))
                    {
                        MessageBox.Show("Hard Disk deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crud.AtualizarSoftware(id, novoProduto, hardDisk);
                    MessageBox.Show("Software Atualizado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Atualizar o Software: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ButtonDeletar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("ID deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crud.DeletarSoftware(id);
                    MessageBox.Show("Software Deletado Com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Deletar o Software: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}