
    using System;
    using System.Data.SQLite;
    using System.Collections.Generic;

    public class Database {

        private string connectionString = "Data Source=./db/estoque.db;Version=3;";

        public Database() {
            this.CriarTabela();
        }

        private void CriarTabela() {
            using (SQLiteConnection conn = new SQLiteConnection(this.connectionString)) {
                conn.Open();

                string sql = @"CREATE TABLE IF NOT EXISTS Carros (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                cor TEXT,
                                preco REAL,
                                ano INTEGER,
                                fabricante TEXT,
                                modelo TEXT UNIQUE,
                                quantidade INTEGER,
                                tipoCombustivel TEXT
                            )";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn)) {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SalvarCarro(Carro carro) {
            using (SQLiteConnection conn = new SQLiteConnection(this.connectionString)) {
                conn.Open();
                string sql = "INSERT OR REPLACE INTO Carros (modelo, preco, quantidade, fabricante, ano, cor, tipoCombustivel) VALUES (@modelo, @preco, @quantidade, @fabricante, @ano, @cor, @tipoCombustivel)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn)) {

                    cmd.Parameters.AddWithValue("@ano", carro.Ano);

                    cmd.Parameters.AddWithValue("@cor", carro.Cor);

                    cmd.Parameters.AddWithValue("@preco", carro.Preco);

                    cmd.Parameters.AddWithValue("@modelo", carro.Modelo);

                    cmd.Parameters.AddWithValue("@quantidade", carro.Quantidade);

                    cmd.Parameters.AddWithValue("@fabricante", carro.Fabricante);

                    cmd.Parameters.AddWithValue("@tipoCombustivel", carro.TipoCombustivel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Carro[] CarregarCarros() {
            
            int count;
        
            using (SQLiteConnection conn = new SQLiteConnection(this.connectionString)) {
                conn.Open();
                string countSql = "SELECT COUNT(*) FROM Carros";
                using (SQLiteCommand countCmd = new SQLiteCommand(countSql, conn)) {
                    count = Convert.ToInt32(countCmd.ExecuteScalar());
                }
            }

            Carro[] carrosArray = new Carro[count];
            int index = 0;

            using (SQLiteConnection conn = new SQLiteConnection(this.connectionString)) {
                conn.Open();
                string sql = "SELECT * FROM Carros";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn)) {
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            string cor = reader["cor"].ToString();
                            int ano = Convert.ToInt32(reader["ano"]);
                            string modelo = reader["modelo"].ToString();
                            decimal preco = Convert.ToDecimal(reader["preco"]);
                            string fabricante = reader["fabricante"].ToString();
                            int quantidade = Convert.ToInt32(reader["quantidade"]);
                            string tipoCombustivel = reader["tipoCombustivel"].ToString();

                            Carro carro = new Carro(ano, cor, modelo, preco, fabricante, tipoCombustivel) {
                                Quantidade = quantidade
                            };

                            carrosArray[index] = carro;
                            index++;
                        }
                    }
                }
            }

            return carrosArray;
        }

        public void RemoverCarro(string modelo) {
            using (SQLiteConnection conn = new SQLiteConnection(this.connectionString)) {
                conn.Open();
                string sql = "DELETE FROM Carros WHERE modelo = @modelo";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

