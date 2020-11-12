# Desafio Stone
O desafio trata de um sistema de cálculo de distribuição de lucro com base em alguma regras. A API disponibilizada deve ser capaz de receber como parâmetro o valor total disponível para esta finalidade e mostrar quanto cada funcionário/estagiário tem direito a receber. Além disso, deve ser mostrado o saldo restante após os cálculo dos valores a serem distribuídos.

Os funcionários precisam ter os seguintes dados: matrícula, nome, departamento, cargo, salário base e data de admissão.

## Regras
As regras para a distribuição do lucro são:
### Peso por área de atuação:
Peso | Área
---| ---
1 | Diretoria
2 | Contabilidade, Financeiro, Tecnologia
3 | Serviços Gerais
5| Relacionamento com o Cliente

### Peso por faixa salarial e uma exceção para estagiários:
Peso | Faixa salarial
--- | ---
5 | Acima de 8 salários mínimos
3 | Acima de 5 salários mínimos e menor que 8 salários mínimos
2 | Acima de 3 salários mínimos e menor que 5 salários mínimos
1 | Todos os estagiários e funcionários que ganham até 3 salários mínimos

### Peso por tempo de admissão:
Peso | Tempo de admissão
--- | ---
1 | Até 1 ano de casa;
2 | Mais de 1 ano e menos de 3 anos;
3 | Acima de 3 anos e menos de 8 anos;
5 | Mais de 8 anos

O cálculo é feito usando a seguinte fórmula:
O valor a ser pago = 12 * ((salario bruto * peso por tempo de admissão) + (salario bruto * peso por área de atuação)) / peso por faixa salarial

Onde 12 se refere ao número de meses em um ano.

## Uso
Esse código foi feito para rodar em asp.net core 3.1. Antes de usar é importante ajustar a string de conexão com o banco de dados no appsettings.json. Não é necessário rodar o Update-Database para criar a base de dados.

O software disponibiliza um CRUD para cadastro de funcionários e uma API para consulta da distribuição de lucros. Abaixo os endpoints disponibilizados.
Endpoint | Função
--- | ---
/ | CRUD para cadastro dos funcionários
/api | API de consulta para a distribuição de lucro.
/api/valor | API com o valor disponibilizado para a distribuição. É preciso usar o . (ponto) como separador de decimal. 

## Créditos
Felipe Mafra

## Licença
Copyleft
