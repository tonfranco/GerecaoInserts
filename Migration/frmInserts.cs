using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using System.IO;
using System.Diagnostics;

namespace Migration
{
    public partial class frmInserts : Form
    {
        private clExecute _objExecute = null;
        private clMessage _objMessage = null;
        private clConnection _objConnection = null;
        private clLoadData _objLoadData = null;
        private List<string> _strInserts = null;
        private TimeSpan _objTimerInicio;
        private string _strTabela = string.Empty;
        private string _strNomeArqGerado = string.Empty;
        private bool _bArquivoDeletado = false;

        public string Tabela
        {
            get { return _strTabela; }
            set { _strTabela = value; }
        }

        public TimeSpan TimerInicio
        {
            get { return _objTimerInicio; }
            set { _objTimerInicio = value; }
        }

        public List<string> Inserts
        {
            get { return _strInserts; }
            set { _strInserts = value; }
        }

        public frmInserts()
        {
            InitializeComponent();
        }

        private void frmInserts_Load(object sender, EventArgs e)
        {

            string arquivo = string.Format("Inserts_{3}_{0}_{1}_{2}.txt",
                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, _strTabela);
            StreamWriter objWt = new StreamWriter(arquivo, false);

            try
            {
                //Inicio teste
                //long lTamnhoString = (long)_strInserts.Count;

                //if (lTamnhoString > 100000)
                //    lTamnhoString = lTamnhoString;
                //Fim teste

                if (_strInserts != null)
                    for (int i = 0; i < _strInserts.Count; i++)
                        objWt.WriteLine(_strInserts[i].ToString());

                if (objWt != null)
                {
                    objWt.Flush();
                    objWt.Close();
                }

                _strNomeArqGerado = arquivo;
                StreamReader objRe = new StreamReader(arquivo);
                txtInserts.Text = objRe.ReadToEnd();

                if (objRe != null)
                    objRe.Close();

                lblErrorInfo.Text = string.Format("{0} insert(s) gerado(s)", _strInserts.Count);
                _objLoadData = new clLoadData();
                _objConnection = new clConnection();
                //_objMessage = new clMessage();

                TimeSpan fim = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                TimeSpan total = new TimeSpan();

                total = fim.Subtract(_objTimerInicio);

                lblInfo.Text = string.Format("Tempo de geração:{0}", total.ToString());
                lklArqGerado.Text = string.Format("{0}{1}", "Arquivo gerado: ", arquivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Migration",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //if (objWt != null)
                //{
                //    objWt.Flush();
                //    objWt.Close();
                //}
            }
        }

        private void tsbExecute_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                executeInsert();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _objExecute = null;
            }
        }

        private void executeInsert()
        {
            _objExecute = new clExecute();
            _objExecute.Query = txtInserts.Text.Trim();
            _objExecute.ServerName = txtServerName.Text.Trim();
            _objExecute.User = txtUser.Text.Trim();
            _objExecute.PWD = txtPwd.Text.Trim();
            _objExecute.DataBase = cboBases.Text.Trim();
            _objExecute.SqlAuthentication = true;

            if (_objExecute.execute())
                MessageBox.Show("Execução realizada com sucesso", "Migration",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _objConnection.ServerName = txtServerName.Text.Trim();
                _objConnection.User = txtUser.Text.Trim();
                _objConnection.PWD = txtPwd.Text.Trim();

                if (rbSQLAut.Checked)
                {
                    if (_objConnection.connection(clConnection.ConnectionType.SQLAuthentication))
                    {
                        _objLoadData.ServerName = _objConnection.ServerName;
                        _objLoadData.User = _objConnection.User;
                        _objLoadData.PWD = _objConnection.PWD;
                        _objLoadData.SqlAuthentication = true;
                        _objLoadData.Query = "USE MASTER SELECT NAME FROM SYSDATABASES WHERE NAME NOT IN ('master','tempdb','msdb','pubs','Northwind','model')";

                        button1.Enabled = false;
                        habilitaControles();
                        fillDataBase(_objLoadData.loadData());
                    }
                    else
                    {
                        if (_objConnection.connection(clConnection.ConnectionType.WindowsAuthentication))
                        {
                            _objLoadData.ServerName = _objConnection.ServerName;
                            _objLoadData.SqlAuthentication = false;
                            _objLoadData.Query = "USE MASTER SELECT NAME FROM SYSDATABASES WHERE NAME NOT IN ('master','tempdb','msdb','pubs','Northwind','model')";
                            fillDataBase(_objLoadData.loadData());

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _objMessage.msgBox("O seguinte erro ocorreu: " + ex.Message, "Migration", clMessage.MessageType.Error);
            }
            finally
            {

            }
        }
        private void habilitaControles()
        {
            try
            {
                grpSelects.Enabled = true;
                grpResults.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillDataBase(DataTable dt)
        {
            cboBases.DataSource = null;
            try
            {
                cboBases.DisplayMember = "NAME";
                cboBases.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtInserts_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F5)
                    executeInsert();
            }
            catch (Exception ex)
            {
                lblErrorInfo.Visible = true;
                lblErrorInfo.Text = ex.Message;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void lklArqGerado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!_bArquivoDeletado)
                    Process.Start(_strNomeArqGerado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_bArquivoDeletado) return;

                if (MessageBox.Show(string.Format("Tem certeza que deseja excluir o arquivo {0}?", _strNomeArqGerado), "Migration",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(Application.StartupPath + "\\" + _strNomeArqGerado);
                    lklArqGerado.Text = "Arquivo deletado";
                    _bArquivoDeletado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Erro ao deletar arquivo {0}.", _strNomeArqGerado),
                    "Migration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}