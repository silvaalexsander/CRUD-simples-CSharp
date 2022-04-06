using Npgsql;
using System;
using System.Collections;
using TesteDB.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        List<Funcionario> funcionarios = new List<Funcionario>();
        Funcionario funcionario;
        
       // 

        while (true)
        {
            Console.WriteLine("\t\t\t>>>>>>>>>>>>>>>>>>Bem Vindo ao CadEmpresa<<<<<<<<<<<<<<<<<<");
            Console.WriteLine($"1 - Cadastro de Funcionário\n2 - Atualizar dados de Funcionário\n3 - Deletar Registro\n4 - Exibir Funcionários Cadastrados\n0 - Para sair do sistema");
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    int op = 1;
                    do
                    {
                        Console.WriteLine("\nInsira os dados do funcionario");
                        funcionario = new Funcionario();
                        Console.Write("Nome: ");
                        funcionario.Nome = Console.ReadLine();
                        Console.Write("CPF: ");
                        funcionario.Cpf = Console.ReadLine();
                        Console.Write("Departamento: ");
                        funcionario.Departamento = Console.ReadLine();
                        Console.Write("Cargo: ");
                        funcionario.Cargo = Console.ReadLine();
                        Console.Write("Salario: ");
                        funcionario.Salario = double.Parse(Console.ReadLine());
                        Console.Write("Contato: ");
                        funcionario.Contato = Console.ReadLine();

                    //    funcionarios.Add(new Funcionario(funcionario.Nome, funcionario.Departamento, funcionario.Cargo, funcionario.Salario, funcionario.Contato, funcionario.Cpf));
                        funcionario.salvarNoBanco(funcionario);

                        Console.WriteLine("Deseja cadastrar novo funcionario?\n1 - SIM\n0 - ENCERRAR");
                        op = int.Parse(Console.ReadLine());

                    } while (op != 0);
                    break;

                case 2:
                    funcionario = new Funcionario();
                    Console.WriteLine("Selecione o campo que deseja atualizar\n1 - Nome\n2 - Departamento\n3 - Cargo\n4 - Salario\n5 - Contato\n6 - CPF\n");
                    int update = int.Parse(Console.ReadLine());
                    string cpf = "";
                    string dado = "";
                    switch (update)
                    {
                        case 1:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo Nome: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(1, dado, cpf);
                            break;

                        case 2:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo Departamento: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(2, dado, cpf);
                            break;

                        case 3:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo Cargo: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(3, dado, cpf);
                            break;

                        case 4:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo Salario: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(4, dado, cpf);
                            break;

                        case 5:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo Contato: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(5, dado, cpf);
                            break;

                        case 6:
                            Console.Write("Insira o CPF do funcionario a ser alterado: ");
                            cpf = Console.ReadLine();
                            Console.Write("Insira o novo CPF: ");
                            dado = Console.ReadLine();
                            funcionario.atualizarRegistro(6, dado, cpf);
                            break;
                    }
                    break;

                case 3:
                    funcionario = new Funcionario();
                    Console.WriteLine("Insira o CPF do usuario a ser deletado");
                    string cp = Console.ReadLine();
                    funcionario.excluiRegistro(cp);
                    break;

                case 4:
                    funcionario = new Funcionario();
                    funcionario.exibirFuncionarios();
                    break;

                default: Console.WriteLine("Opção Inválida");
                    break;
            }
            if(escolha == 0)
            {
                break;
            }
        }
        
    }
}