DELETE FROM Transacoes;
DELETE FROM Categorias;

INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Alimentação', 'Despesas com alimentos e bebidas', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Saúde', 'Gastos com saúde e bem-estar', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Transporte', 'Custos com transporte e veículos', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Moradia', 'Despesas relacionadas à casa', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Educação', 'Gastos com educação e cursos', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Lazer', 'Despesas com atividades de lazer', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Roupas', 'Gastos com vestuário', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Investimentos', 'Investimentos e aplicações financeiras', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Impostos', 'Pagamentos de impostos e taxas', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Viagem', 'Despesas com viagens e turismo', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Presentes', 'Gastos com presentes e doações', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Beleza', 'Despesas com beleza e cuidados pessoais', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Pets', 'Gastos com animais de estimação', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Telefonia', 'Custos com telefonia e internet', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Seguros', 'Pagamentos de seguros diversos', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Saúde Mental', 'Despesas com psicologia e terapias', 'ricardopim@msn.com');
INSERT INTO [dbo].[Categorias] (Titulo, Descricao, CodigoUsuario) VALUES ('Fitness', 'Gastos com academia e atividades físicas', 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de supermercado', '2026-05-05', '2026-05-05', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Academia', '2026-05-10', '2026-05-10', 2, -89.99, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Fitness'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Passagem de ônibus', '2026-05-15', '2026-05-15', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Livros para curso', '2026-05-20', '2026-05-20', 2, -200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário', '2026-05-25', '2026-05-25', 1, 5000.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta médica', '2026-05-26', '2026-05-26', 2, -250.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Jantar fora', '2026-05-27', '2026-05-27', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Ração para cachorro', '2026-05-28', '2026-05-28', 2, -75.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento de seguro de vida', '2026-05-29', '2026-05-29', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Seguros'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Netflix', '2026-06-02', '2026-06-02', 2, -45.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Roupa nova', '2026-06-06', '2026-06-06', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Roupas'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conserto do carro', '2026-06-11', '2026-06-11', 2, -800.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Corte de cabelo', '2026-06-15', '2026-06-15', 2, -50.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Beleza'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de livros', '2026-06-18', '2026-06-18', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Reembolso de viagem', '2026-06-20', '2026-06-20', 1, 1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Viagem'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Aluguel de fevereiro', '2026-06-25', '2026-06-25', 2, -1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('IPVA', '2026-06-27', '2026-06-27', 2, -400.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Impostos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta veterinária', '2026-06-28', '2026-06-28', 2, -180.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Jantar de aniversário', '2026-06-28', '2026-06-28', 2, -250.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário Mensal', '2026-07-01', '2026-07-01', 1, 5000.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Luz', '2026-07-02', '2026-07-02', 2, -120.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Água', '2026-07-05', '2026-07-05', 2, -80.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Escolar', '2026-07-10', '2026-07-10', 2, -600.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Roupas', '2026-07-12', '2026-07-12', 2, -300.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Roupas'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Suplementos', '2026-07-15', '2026-07-15', 2, -200.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Restaurante com a Família', '2026-07-18', '2026-07-18', 2, -250.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Plano de Telefonia', '2026-07-20', '2026-07-20', 2, -150.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Telefonia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Viagem de Fim de Semana', '2026-07-22', '2026-07-22', 2, -800.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Viagem'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento Seguro Carro', '2026-07-24', '2026-07-24', 2, -400.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Seguros'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Material de Arte', '2026-07-26', '2026-07-26', 2, -150.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Receita de Freelance', '2026-08-02', '2026-08-02', 1, 2200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Internet', '2026-08-05', '2026-08-05', 2, -89.99, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Telefonia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Despesa com Transporte', '2026-08-07', '2026-08-07', 2, -160.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Livros', '2026-08-09', '2026-08-09', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário', '2026-08-10', '2026-08-10', 1, 4000.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento do Aluguel', '2026-08-12', '2026-08-12', 2, -1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Gastos com Jantar', '2026-08-15', '2026-08-15', 2, -200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta Médica', '2026-08-18', '2026-08-18', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Ração para Pet', '2026-08-20', '2026-08-20', 2, -75.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Presente de Aniversário', '2026-08-22', '2026-08-22', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Presentes'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Bonificação', '2026-08-24', '2026-08-24', 1, 1200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de supermercado', '2026-09-05', '2026-09-05', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Academia', '2026-09-10', '2026-09-10', 2, -89.99, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Fitness'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Passagem de ônibus', '2026-09-15', '2026-09-15', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Livros para curso', '2026-09-20', '2026-09-20', 2, -200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário', '2026-09-25', '2026-09-25', 1, 5000.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta médica', '2026-09-26', '2026-09-26', 2, -250.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Jantar fora', '2026-09-27', '2026-09-27', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Ração para cachorro', '2026-09-28', '2026-09-28', 2, -75.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento de seguro de vida', '2026-09-29', '2026-09-29', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Seguros'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Netflix', '2026-09-02', '2026-09-02', 2, -45.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Roupa nova', '2026-09-06', '2026-09-06', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Roupas'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conserto do carro', '2026-09-11', '2026-09-11', 2, -800.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Corte de cabelo', '2026-09-15', '2026-09-15', 2, -50.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Beleza'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de livros', '2026-09-18', '2026-09-18', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Reembolso de viagem', '2026-09-20', '2026-09-20', 1, 1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Viagem'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Aluguel de fevereiro', '2026-09-25', '2026-09-25', 2, -1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('IPVA', '2026-09-27', '2026-09-27', 2, -400.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Impostos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta veterinária', '2026-09-28', '2026-09-28', 2, -180.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Jantar de aniversário', '2026-09-28', '2026-09-28', 2, -250.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário Mensal', '2026-10-01', '2026-10-01', 1, 5000.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Luz', '2026-10-02', '2026-10-02', 2, -120.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Água', '2026-10-05', '2026-10-05', 2, -80.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Mensalidade Escolar', '2026-10-10', '2026-10-10', 2, -600.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Roupas', '2026-10-12', '2026-10-12', 2, -300.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Roupas'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Suplementos', '2026-10-15', '2026-10-15', 2, -200.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Restaurante com a Família', '2026-10-18', '2026-10-18', 2, -250.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Plano de Telefonia', '2026-10-20', '2026-10-20', 2, -150.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Telefonia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Viagem de Fim de Semana', '2026-10-22', '2026-10-22', 2, -800.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Viagem'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento Seguro Carro', '2026-10-24', '2026-10-24', 2, -400.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Seguros'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Material de Arte', '2026-10-26', '2026-10-26', 2, -150.00, (SELECT TOP 1 Codigo FROM [dbo].[Categorias] WHERE Titulo='Lazer'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Receita de Freelance', '2026-10-02', '2026-10-02', 1, 2200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Conta de Internet', '2026-10-05', '2026-10-05', 2, -89.99, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Telefonia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Despesa com Transporte', '2026-10-07', '2026-10-07', 2, -160.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Transporte'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Compra de Livros', '2026-10-09', '2026-10-09', 2, -120.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Educação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Salário', '2026-10-10', '2026-10-10', 1, 4000.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Pagamento do Aluguel', '2026-10-12', '2026-10-12', 2, -1500.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Moradia'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Gastos com Jantar', '2026-10-15', '2026-10-15', 2, -200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Alimentação'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Consulta Médica', '2026-10-18', '2026-10-18', 2, -300.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Saúde'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Ração para Pet', '2026-10-20', '2026-10-20', 2, -75.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Pets'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Presente de Aniversário', '2026-10-22', '2026-10-22', 2, -150.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Presentes'), 'ricardopim@msn.com');

INSERT INTO [dbo].[Transacoes] (Titulo, DataCadastro, DataPagamento, Tipo, Valor, CodigoCategoria, CodigoUsuario)
VALUES ('Bonificação', '2026-10-24', '2026-10-24', 1, 1200.00, (SELECT Codigo FROM [dbo].[Categorias] WHERE Titulo='Investimentos'), 'ricardopim@msn.com');
