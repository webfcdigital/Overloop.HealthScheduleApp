# Sistema de Agendamento Médico Serverless

Este projeto é uma implementação de um sistema de agendamento médico, construído com uma arquitetura serverless na AWS, utilizando C# e .NET 8.

## 1. Contexto de Negócio

O sistema é uma plataforma para conectar pacientes e médicos. Ele permite que pacientes busquem médicos por especialidade e agendem consultas. Médicos, por sua vez, podem gerenciar sua agenda e receber notificações de novos agendamentos.

### Entidades do Domínio (DDD)

*   **Paciente**: Um usuário que busca e agenda consultas.
*   **Medico**: Um profissional de saúde com uma especialidade, que disponibiliza horários para consultas.
*   **Consulta**: O principal agregado do sistema. Representa o agendamento de um encontro entre um Paciente e um Medico. Possui um status (agendada, cancelada, concluída) e uma data/hora.
*   **Agenda**: Representa os horários disponíveis de um Medico.

## 2. Arquitetura da Solução

Utilizamos uma arquitetura orientada a eventos e serverless na AWS para promover escalabilidade, resiliência e alta disponibilidade.

*   **Back-end**: Uma coleção de funções AWS Lambda que expõem uma API via Amazon API Gateway. A comunicação entre os serviços é desacoplada usando Amazon SQS e SNS.
*   **Banco de Dados**: Amazon DynamoDB.

## 3. Decisões de Tecnologia e Princípios de Design

*   **Linguagem de Programação**: C# (.NET 8)
*   **Padrões de Design**:
    *   Domain-Driven Design (DDD)
    *   SOLID
    *   Injeção de Dependência (DI)
*   **Segurança**: Autenticação e Autorização gerenciadas pelo Auth0.
*   **Infraestrutura como Código (IaC)**: Gerenciamento de recursos da AWS com ferramentas como AWS CloudFormation, Terraform ou Pulumi.
*   **Containerização**: Docker para empacotar as aplicações, garantindo um ambiente de execução consistente.