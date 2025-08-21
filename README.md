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

## 4. Execução Local com AWS SAM CLI

Para simular o ambiente AWS localmente e testar a aplicação, utilize o AWS SAM CLI. Certifique-se de ter o Docker instalado e em execução, pois o SAM CLI utiliza contêineres Docker para emular as funções Lambda.

1.  **Construir o Projeto SAM:**
    Navegue até o diretório raiz do projeto e execute o comando `sam build`. Este comando prepara sua aplicação para execução local, criando as imagens Docker necessárias.

    ```bash
    sam build
    ```

2.  **Iniciar a API Localmente:**
    Após a construção, você pode iniciar um endpoint local do API Gateway que invocará sua função Lambda.

    ```bash
    sam local start-api
    ```

    A API estará disponível em `http://127.0.0.1:3000`. Você poderá enviar requisições para os endpoints definidos (ex: `http://127.0.0.1:3000/consultas`).

    **Observação:** Para que o SAM CLI possa se comunicar com os serviços locais do DynamoDB e SNS (se você estiver usando ferramentas como o LocalStack), você precisará configurar as variáveis de ambiente ou o arquivo de credenciais da AWS para apontar para o endpoint local.
