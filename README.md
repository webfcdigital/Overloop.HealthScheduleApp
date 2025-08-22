# Serverless Medical Scheduling System

This project is an implementation of a medical scheduling system, built with a serverless architecture on AWS, using C# and .NET 8.

## 1. Business Context

The system is a platform for connecting patients and doctors. It allows patients to search for doctors by specialty and schedule appointments. Doctors, in turn, can manage their schedules and receive notifications of new appointments.

### Domain Entities (DDD)

* **Patient**: A user who searches for and schedules appointments.
* **Doctor**: A healthcare professional with a specialty who makes appointments available.
* **Appointment**: The main aggregate of the system. It represents the scheduling of an appointment between a patient and a doctor. It has a status (scheduled, canceled, completed) and a date/time.
* **Schedule**: Represents a doctor's available appointments.

## 2. Solution Architecture

We use an event-driven, serverless architecture on AWS to promote scalability, resilience, and high availability.

* **Backend**: A collection of AWS Lambda functions that expose an API via Amazon API Gateway. Communication between services is decoupled using Amazon SQS and SNS.
* **Database**: Amazon DynamoDB.

## 3. Technology Decisions and Design Principles

* **Programming Language**: C# (.NET 8)
* **Design Patterns**:
* Domain-Driven Design (DDD)
* SOLID
* Dependency Injection (DI)
* **Security**: Authentication and Authorization managed by Auth0.
* **Infrastructure as Code (IaC)**: AWS resource management with tools such as AWS CloudFormation, Terraform, or Pulumi. Containerization: Docker to package applications, ensuring a consistent execution environment.

4. Local Execution with AWS SAM CLI

To simulate the AWS environment locally and test the application, use the AWS SAM CLI. Make sure you have Docker installed and running, as the SAM CLI uses Docker containers to emulate Lambda functions.

1. Build the SAM Project:
Navigate to the project root directory and run the sam build command. This command prepares your application for local execution by creating the necessary Docker images.

bash
sam build

2. Start the API Locally:
After building, you can start a local API Gateway endpoint that will invoke your Lambda function.

bash
sam local start-api


The API will be available at http://127.0.0.1:3000. You can send requests to the defined endpoints (e.g., `http://127.0.0.1:3000/consultas`).

**Note:** In order for the SAM CLI to communicate with local DynamoDB and SNS services (if you're using tools like LocalStack), you'll need to configure your environment variables or AWS credentials file to point to the local endpoint.