﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Runtime.InteropServices;

namespace DAL
{
    public class DBController : IDBController
    {

        public void commit()
        {
            OracleCommand comando = new OracleCommand("commit", DBCon.getCon());
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }

        public string validaEmail(string email)
        {
            List<DBUsuarios> lista = getUsuarios("email='" + email + "'");
            if (lista.Count == 1)
            {
                OracleCommand comando = new OracleCommand("update usuarios set status=1 where email='" + email + "'", DBCon.getCon());
                comando.ExecuteNonQuery();
                Debug.WriteLine("Validado usuario com email:" + email);
                comando.Dispose();
                comando.Connection.Close();
                return "0x00";
            }
            else
            {
                Debug.WriteLine("Nenhum usuário validado");
                return "0x01";
            }

        }

        public List<DBUsuarios> getUsuarios([Optional] string _condicao)

        {

            Debug.WriteLine("Executado metodo getUsuarios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }


            OracleCommand comando = new OracleCommand("select usid,status,nome,email,telefone,datacadastro,senha from usuarios " + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBUsuarios> lista = new List<DBUsuarios>();
                while (leitor.Read())
                {
                    lista.Add(new DBUsuarios(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetString(2), leitor.GetString(3), leitor.GetString(4), leitor.GetDateTime(5), leitor.GetString(6)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBUsuarios>();
            }
        }

        public List<DBAnuncios> getAnuncios([Optional] string _condicao)
        {
            Debug.WriteLine("Executado metodo getAnuncios com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }
            Debug.WriteLine("select aid, usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo from anuncio " + condicao);
            OracleCommand comando = new OracleCommand("select aid, usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo from anuncio " + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBAnuncios> lista = new List<DBAnuncios>();
                while (leitor.Read())
                {
                    lista.Add(new DBAnuncios(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2), leitor.GetInt32(3), leitor.GetInt32(4), leitor.GetDateTime(5), leitor.GetDateTime(6), leitor.GetString(7), leitor.GetString(8)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBAnuncios>();
            }

        }

        public List<DBImagens> getImagens([Optional] string _condicao)
        {
            Debug.WriteLine("Executado metodo getImagem com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }
            OracleCommand comando = new OracleCommand("select iid,aid,nome,caminho from imagens " + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBImagens> lista = new List<DBImagens>();
                while (leitor.Read())
                {
                    lista.Add(new DBImagens(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetString(2), leitor.GetString(3)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBImagens>();
            }

        }

        public List<DBCandidatos> getCandidatos([Optional] string _condicao)
        {

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }
            Debug.WriteLine("Executado metodo getCandidatos com o parâmetro: " + _condicao);
            OracleCommand comando = new OracleCommand("select canid, usid, aid from candidatos " + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBCandidatos> lista = new List<DBCandidatos>();
                while (leitor.Read())
                {
                    lista.Add(new DBCandidatos(leitor.GetInt32(0), leitor.GetInt32(1), leitor.GetInt32(2)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBCandidatos>();
            }

        }

        public List<DBCategorias> getCategorias([Optional] string _condicao)
        {
            Debug.WriteLine("Executado metodo getCategorias com o parâmetro: " + _condicao);

            string condicao = "";

            if (_condicao != null)
            {
                condicao = "where " + _condicao;
            }
            OracleCommand comando = new OracleCommand("select cid,nome from categorias " + condicao, DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                List<DBCategorias> lista = new List<DBCategorias>();
                while (leitor.Read())
                {
                    lista.Add(new DBCategorias(leitor.GetInt32(0), leitor.GetString(1)));
                }
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                return lista;
            }
            else
            {
                comando.Dispose();
                leitor.Dispose();
                comando.Connection.Close();
                Debug.WriteLine(DateTime.Now + " -- Retornada lista vazia");
                return new List<DBCategorias>();
            }
        }


        public void addCandidato(int _usid, int _aid)
        {
            OracleCommand comando = new OracleCommand("insert into candidatos (usid, aid) values(" + _usid + "," + _aid + ")", DBCon.getCon());
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando.Connection.Close();
            commit();
            Debug.WriteLine("Executado: insert into candidatos (usid, aid) values(" + _usid + "," + _aid + ")");

        }

        public string addAnuncio(int usid, int cid, int tipo, int status, int duracao, string descricao, string titulo, string caminhoImg, string nomeImg)
        {

            string datacriacao = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string dataexpiracao = DateTime.Now.AddDays(duracao).Day + "/" + DateTime.Now.AddDays(duracao).Month + "/" + DateTime.Now.AddDays(duracao).Year + " " + DateTime.Now.AddDays(duracao).Hour + ":" + DateTime.Now.AddDays(duracao).Minute + ":" + DateTime.Now.AddDays(duracao).Second;
            Debug.WriteLine("Executado: insert into anuncio(usid, cid, tipo, status, datacriacao, dataexpiracao, descricao, titulo) values(" + usid + ", " + cid + ", " + tipo + ", " + status + ", to_date('" + datacriacao + "', 'DD/MM/YYYY hh24:mi:ss'), " + "to_date('" + dataexpiracao + "', 'DD/MM/YYYY hh24:mi:ss')" + ", '" + descricao + "', '" + titulo + "')");
            OracleCommand comando = new OracleCommand("insert into anuncio (usid,cid,tipo,status,datacriacao,dataexpiracao,descricao,titulo) values (" + usid + "," + cid + "," + tipo + "," + status + ",to_date('" + datacriacao + "','DD/MM/YYYY hh24:mi:ss')," + "to_date('" + dataexpiracao + "','DD/MM/YYYY hh24:mi:ss')" + ",'" + descricao + "','" + titulo + "')", DBCon.getCon());
            string resultado = "0x00";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                resultado = ex.Number.ToString();
            }
            if (caminhoImg != "" && nomeImg != "")
            {
                addImagem(caminhoImg, nomeImg);
            }
            comando.Dispose();
            comando.Connection.Close();
            commit();
            return resultado;
        }

        public string addUsuario(string nome, string email, string telefone, string senha, string estado, string cidade)
        {
            string datacriacao = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            Debug.WriteLine("Executado SQL:" + "insert into USUARIOS (status,nome,email,telefone,datacadastro,senha) values(0,'" + nome + "','" + email + "','" + telefone + "',to_date('" + datacriacao + "', 'DD/MM/YYYY'),'" + senha + "')");
            OracleCommand comando = new OracleCommand("insert into USUARIOS (status,nome,email,telefone,datacadastro,senha) values(0,'" + nome + "','" + email + "','" + telefone + "',to_date('" + datacriacao + "', 'DD/MM/YYYY'),'" + senha + "')", DBCon.getCon());
            string resultado = "0x00";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                resultado = ex.Number.ToString();
            }

            comando.Dispose();
            comando.Connection.Close();
            Debug.WriteLine(resultado);
            return resultado;
        }

        public string enviaMensagem(int usidremetente, int usiddestinatario, string conteudo, int aid)
        {
            Debug.WriteLine("Executado SQL:" + "insert into MENSAGENS (usidremetente,usiddestinatario,conteudo,aid,hora) values(" + usidremetente + "," + usiddestinatario + ",'" + conteudo + "'," + aid + ", (select sysdate from dual))");
            OracleCommand comando = new OracleCommand("insert into MENSAGENS (usidremetente,usiddestinatario,conteudo,aid,hora) values(" + usidremetente + "," + usiddestinatario + ",'" + conteudo + "'," + aid + ", (select sysdate from dual))", DBCon.getCon());
            string resultado = "0x00";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                resultado = ex.Number.ToString();
            }

            comando.Dispose();
            comando.Connection.Close();
            Debug.WriteLine(resultado);
            return resultado;
        }



        private void addImagem(string caminho, string nome)
        {
            OracleCommand comando = new OracleCommand("SELECT last_number FROM user_sequences WHERE SEQUENCE_NAME = 'SEQUENCE_AID'", DBCon.getCon());
            OracleDataReader leitor = comando.ExecuteReader();
            int ultimoAnuncio = 0;
            while (leitor.Read())
            {
                ultimoAnuncio = leitor.GetInt32(0) - 1;
            }
            Debug.WriteLine("insert into imagens (aid, caminho, nome) values (" + ultimoAnuncio + ",'" + caminho + "','" + nome + "')");
            comando = new OracleCommand("insert into imagens (aid, caminho, nome) values (" + ultimoAnuncio + ",'" + caminho + "','" + nome + "')", DBCon.getCon());
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando.Connection.Close();
        }

    }//End Classe
}//End Namespace
