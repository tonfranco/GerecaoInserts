using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Globalization;
using System.Threading;


namespace Migration
{
    public partial class Form1 : Form
    {
        private clMessage _objMessage = null;
        private clConnection _objConnection = null;
        private clLoadData _objLoadData = null;
        private TimeSpan _tsTotal  ;
        private TimeSpan _tsInicio;
        private TimeSpan _tsFim;

        public Form1()
        {
            InitializeComponent();
        }

        private void rbWindowsAut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                connectionMode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void connectionMode()
        {
            try
            {
                if (rbSQLAut.Checked)
                {
                    txtPwd.Enabled = true;
                    txtUser.Enabled = true;
                }
                else
                {
                    txtPwd.Enabled = false;
                    txtUser.Enabled = false;
                    txtUser.Text = string.Empty;
                    txtPwd.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                _objMessage.msgBox("O seguinte erro ocorreu: " + ex.Message, "Migration", clMessage.MessageType.Error);
            }
        }

        private void rbSQLAut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                connectionMode();
            }
            catch (Exception ex)
            {
                _objMessage.msgBox("O seguinte erro ocorreu: " + ex.Message, "Migration", clMessage.MessageType.Error);
            }
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
                        fillDataBase(_objLoadData.loadData());
                        button1.Enabled = false;
                        habilitaControles();
                    }
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
            catch (Exception ex)
            {
                _objMessage.msgBox("O seguinte erro ocorreu: " + ex.Message, "Migration", clMessage.MessageType.Error);
            }
            finally
            {

            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                desabilitaControles();
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

        private void habilitaControles()
        {
            try
            {
                grpSelects.Enabled = true;
                grpResults.Enabled = true;
                btnDisconnect.Enabled = true;
                btnFind.Enabled = true;
                txtFind.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void desabilitaControles()
        {
            try
            {
                grpSelects.Enabled = false;
                grpResults.Enabled = false;
                txtSelects.Text = string.Empty;
                dgvResult.DataSource = null;
                lblErrorInfo.Text = string.Empty;
                cboBases.DataSource = null;
                button1.Enabled = true;
                btnDisconnect.Enabled = false;
                txtTbDestino.Text = string.Empty;
                lblInfoGrid.Text = string.Empty;
                btnFind.Enabled = false;
                txtFind.Enabled = false;
                txtFind.Text = string.Empty;
                pgbLoad.Value = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSelects.Text.Trim() == string.Empty) return;



                //Thread objThread = new Thread(executeSelect);

                this.Cursor = Cursors.WaitCursor;
                executeSelect();
                
                //objThread.Start();

                lblErrorInfo.Visible = false;
                dgvResult.Visible = true;
                lblErrorInfo.Text = "";

            }
            catch (Exception ex)
            {
                lblErrorInfo.Visible = true;
                dgvResult.Visible = false;
                lblErrorInfo.Text = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void executeSelect()
        {
            try
            {
                _tsInicio = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Application.DoEvents();
                pictureBox1.Visible = true;
                pgbLoad.Minimum = 1;
                pgbLoad.Maximum = 1000;
                pgbLoad.Value = 350;

                this.Cursor = Cursors.WaitCursor;
                string query = string.Empty;

                if (dataBaseSelected())
                {
                    query = string.Format("use {0} {1}", cboBases.Text, (txtSelects.SelectedText.Trim().Length > 0 ? txtSelects.SelectedText : txtSelects.Text.Trim()));
                    _objLoadData.Query = query;
                    dgvResult.DataSource = _objLoadData.loadData();
                }
                else
                    _objMessage.msgBox("Escolha a Base de dados", "Migration", clMessage.MessageType.Information);
                
                _tsFim = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                _tsTotal = _tsFim.Subtract(_tsInicio);
                infoGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Thread.Sleep(100);
                pgbLoad.Value = 700;
                Thread.Sleep(300);
                this.Cursor = Cursors.Default;
                pgbLoad.Value = 1000;
                pictureBox1.Visible = false;
            }
        }

        private void infoGrid()
        {
            try
            {
                lblInfoGrid.Text = string.Format("{0} Row(s)   |   {1} SelectedRow(s)  |  Tempo de geração: {2}",
                                                            dgvResult.Rows.Count, dgvResult.SelectedRows.Count,_tsTotal.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _objLoadData = new clLoadData();
                _objConnection = new clConnection();
                _objMessage = new clMessage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool dataBaseSelected()
        {
            bool bRet = false;
            try
            {
                if (cboBases.Text == string.Empty)
                    bRet = false;
                else
                    bRet = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return bRet;
        }

        private void tsbGeraInserts_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTbDestino.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtTbDestino, "Insira o nome da Tabela Destino");
                    return;
                }
                else
                    errorProvider1.Clear();

                Application.DoEvents();
                grpGerando.Visible = true;

                this.Cursor = Cursors.WaitCursor;
                frmInserts objFrm = new frmInserts();

                objFrm.TimerInicio = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); ;
                objFrm.Tabela = txtTbDestino.Text.Trim();

                System.Threading.Thread.CurrentThread.CurrentCulture = alteraCulturaThread(true);
                objFrm.Inserts = generationInserts.InsertsFromQuery((DataTable)dgvResult.DataSource, txtTbDestino.Text);
                grpGerando.Visible = false;
                objFrm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Migration",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                grpGerando.Visible = false;
            }
        }

        private CultureInfo alteraCulturaThread(bool ponto)
        {
            //Passar para o Frmk - Gustavo.
            System.Globalization.CultureInfo obj = null;

            try
            {
                if (ponto)
                {
                    obj = new System.Globalization.CultureInfo("PT-BR", true);
                    obj.NumberFormat.CurrencyGroupSeparator = ",";
                    obj.NumberFormat.CurrencyDecimalSeparator = ".";
                    obj.NumberFormat.NumberGroupSeparator = ",";
                    obj.NumberFormat.NumberDecimalSeparator = ".";
                    System.Threading.Thread.CurrentThread.CurrentCulture = obj;
                }
                else
                {
                    obj = new System.Globalization.CultureInfo("PT-BR", true);
                    obj.NumberFormat.CurrencyGroupSeparator = ".";
                    obj.NumberFormat.CurrencyDecimalSeparator = ",";
                    obj.NumberFormat.NumberGroupSeparator = ".";
                    obj.NumberFormat.NumberDecimalSeparator = ",";
                    System.Threading.Thread.CurrentThread.CurrentCulture = obj;
                }
            }
            catch (Exception ex)
            {
                obj = null;

            }

            return obj;
        }

        private void txtSelects_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                infoGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSelects_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSelects_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F5)
                    executeSelect();

            }
            catch (Exception ex)
            {
                lblErrorInfo.Visible = true;
                dgvResult.Visible = false;
                lblErrorInfo.Text = ex.Message;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                findText();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void findText()
        {
            try
            {
                if (txtFind.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtFind, "Insira o texto a ser procurado");
                    return;
                }
                else
                    errorProvider1.Clear();

                if (txtSelects.Find(txtFind.Text.Trim()) > 0)
                {
                    txtSelects.Focus();
                    txtSelects.SelectionStart = (txtSelects.Find(txtFind.Text.Trim()));
                    lblNotFind.Text = string.Empty;
                    lblNotFind.Visible = false;
                }
                else
                {
                    lblNotFind.Text = string.Format("'{0}' não encontrado", txtFind.Text);
                    lblNotFind.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSelects_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.KeyCode == Keys.F5)
                {
                    executeSelect();
                    lblErrorInfo.Visible = false;
                    dgvResult.Visible = true;
                    lblErrorInfo.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorInfo.Visible = true;
                dgvResult.Visible = false;
                lblErrorInfo.Text = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    findText();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}