using Npgsql;

namespace TesteDB.Classes
{
    public class Funcionario
    {
        List<Funcionario> funcionarios = new List<Funcionario>();
        Conexao con = new Conexao();
        NpgsqlCommand cmd = new NpgsqlCommand();

        private string nome = "";
        private string cpf = "";
        private string departamento = "";
        private string cargo = "";
        private double salario = 0.0;
        private string contato = "";

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public string Contato { get; set; }
        public Funcionario()
        {

        }
        public Funcionario(string nome, string departamento, string cargo, double salario, string contato, string cpf)
        {
            this.nome = nome;
            this.departamento = departamento;
            this.cargo = cargo;
            this.salario = salario;
            this.contato = contato;
            this.Cpf = cpf;
        }

    
      
       /* public void exibirFun(List<Funcionario> vs)
        {
            foreach (var item in vs)    
            {
                Console.WriteLine($"Nome: {item.nome}\nCPF: {item.Cpf}\nDepartamento: {item.departamento}\nCargo: {item.cargo}\nSalario: {item.salario}\nContato: {item.contato}\n");
            }
        }*/

        public void salvarNoBanco(Funcionario vs)
        {        
             cmd.CommandText = "INSERT INTO funcionario (cpf, nome, departamento," +
                    "cargo, salario, contato) VALUES" +
                    "(@cpf, @nome, @departamento, @cargo, @salario, @contato)";
            cmd.Parameters.AddWithValue("@cpf", vs.Cpf);
            cmd.Parameters.AddWithValue("@nome", vs.Nome);
            cmd.Parameters.AddWithValue("@departamento", vs.Departamento);
            cmd.Parameters.AddWithValue("@cargo", vs.Cargo);
            cmd.Parameters.AddWithValue("@salario", vs.Salario);
            cmd.Parameters.AddWithValue("@contato", vs.Contato);
                
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconctar();
                Console.WriteLine("\nSalvo Com Sucesso\n");
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public void excluiRegistro(string cpf)
        {
            cmd.CommandText = "DELETE FROM funcionario WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconctar();
                Console.WriteLine("Registro Deletado");
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString()); ;
            }
        }

        public void exibirFuncionarios()
        {
            cmd.CommandText = "SELECT * FROM funcionario ORDER BY nome";
            
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("Cod.Fun\t\tNome\t\t\tDepartamento\t\tCargo\t\tSalário\t\tContato\t\tCpf");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}\t{dr[2]}\t\t{dr[3]}\t" +
                        $"{dr[4]}\t\t{dr[5]}\t{dr[6]}");
                }
                con.desconctar();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void atualizarRegistro(int indice, string dado, string cpf)
        {
            switch (indice)
            {
                case 1:
                    cmd.CommandText = "UPDATE funcionario SET nome = @nome WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@nome", dado);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;

                case 2:
                    cmd.CommandText = "UPDATE funcionario SET departamento = @departamento WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@departamento", dado);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;

                case 3:
                    cmd.CommandText = "UPDATE funcionario SET cargo = @cargo WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@cargo", dado);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;

                case 4:
                    double salario = Convert.ToDouble(dado);
                    cmd.CommandText = "UPDATE funcionario SET salario = @salario WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@salario", salario);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;

                case 5:
                    cmd.CommandText = "UPDATE funcionario SET contato = @contato WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@contato", dado);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;

                case 6:
                    cmd.CommandText = "UPDATE funcionario SET cpf = @dado WHERE cpf = @cpf";
                    cmd.Parameters.AddWithValue("@dado", dado);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    break;
            }

            cmd.Connection = con.conectar();
            cmd.ExecuteNonQuery();
            con.desconctar();
            Console.WriteLine("\nRegistro atualizado com sucesso!\n");
        }

    }
}
