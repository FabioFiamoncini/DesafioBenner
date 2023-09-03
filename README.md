# DesafioBenner

Parking Car - Controle de estacionamento

Aplicativo Web desenvolvido em C#, utilizando as seguintes tecnologias open source:
> Templates do ASP.NET MVC
> Pacotes do Entity Framework 7
> IDE Visual Studio 2022 (pacotes de banco de dados, SQL Server Express/LocalDB)

A solução requer uma instância do banco de dados local em LocalDB para ser executada.
Versões do SQL Server Express, que contém a instalação do LocalDB (2019+), podem ser baixadas no link abaixo, na seção "Installation media":
>> https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16

Com o LocalDB, para criar o banco de dados, dentro do Visual Studio acessar o Console do Gerenciador de Pacotes do NuGet e executar os seguintes comandos (requer EF 7):
Add-Migration <nome>
Update-Database

Com o banco de dados criado no LocalDB, o aplicativo pode ser executado.
--

Instruções de uso:

O aplicativo simula um sistema de controle de estacionamento, em que o usuário pode registrar as entradas, saídas e parâmetrizar os preços aplicados por período.

O usuário inicialmente deve ir no cadastro de preços, acessado pelo menu superior em qualquer página, onde deve ser cadastrado um valor inicial cobrado na primeira hora, e o valor
adicional das horas cobradas subsequentemente. Também deve ser informado um período de vigência com uma data inicial e final desses valores, na qual os controles registrados
utilizam como referência para calcular o valor final das estadias ao registrar saída.

Com um preço cadastrado, o usuário pode registrar as entradas (apenas placa do veículo e tempo da entrada) e posteriormente registrar as saídas desses controles na página inicial.
Ao registrar saída, o usuário deve informar os valores (que já estarão preenchidos, de acordo com tabela de preços) e o tempo de saída, em que o programa irá calcular
o valor final da estadia no estacionamento. É aplicada uma regra de tolerância de até 10 minutos após uma hora de estadia até ser cobrado a hora seguinte.

A quantidade de horas e minutos de cada controle, bem como a informação dos tempos de entrada/saída e valores, estarão todas disponíveis na página inicial após ser registrado a saída.
Há também uma função de filtragem dos registros na página inicial, que faz a busca a partir da placa dos veículos. O valor final e os tempos de hora/minutos não são preenchidos até ser
registrado a saída de determinado controle.

--

*Este programa foi desenvolvido como requisito de processo seletivo, seu uso NÃO é recomendado para nenhuma outra finalidade.
