# Desafio Técnico - Sistema Caixa de Banco daVindi

## Informações gerais

* API C#, criada com .NET 8;
  
* Foi criada a classe "ServiceResult" (Result Pattern) para padronizar o retorno das mensagens e erros;
  
* O projeto possui Swagger;
  
* A Program foi "enxugada" utilizando extension methods para configurar Banco de dados, IoC etc;

* O projeto foi criado respeitando os princípios SOLID, responsabilidades separadas, segregação com interfaces etc;
  
* Foi aplicado CQRS (Command Query Responsibility Segregation) nas controllers, para um direcionamento de escalabilidade e manutebilidade;

* Implementação de Repositório Genérico, para evitar verbosidade e gerar reaproveitamento;
  
* Implementado alguns princípios do DDD deixando ainda em aberto a possibilidade de tornar os domínios "Ricos";

* Para fins de praticidade, foi utilizado InMemoryDatabase;

* Há margens para melhorias, como Unity Of Work, Exception Handler, Docker etc; porém o meu foco foi em arquitetura.
