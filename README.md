# Kafka Integration Demonstration

## What I have created:

- Basic producer service that can send messages to a Kafka Topic
- Basic consumer service that reads messages from the topic
- REST API endpoint to submit messages
- Basic error handling and logging


## How it works
Well written code speaks for itself, thats why I will give a comprehensive guide

1. The producer service accepts messages via the REST API
2. Messages are published to a kafka topic called orders.
3. The consumer service continously reads the messages from the topic


## What I learned

Even though this was a basic introduction to Kafka from me I thought it would be nice to share it with you guys
- Kafkas basic architecture, topics, consumers and producers
- How to integrate it with ASP.NET core
- Basic message publishing and consumption patterns
- Error handling

## I quickly read upon Kafka and realized I do a lot of the "production" ready practices in my current job.

Forexample
1. Configuration management through appsettings.json
    - Just like my other projects, I would move the configs to the appsettings.json and get the Section in the program.cs.
2. Reliability
    - Add some retry policies, perhaps even some proper message acknowledgment and a circut breaker
3. Monitoring
    - Add some real logging not just Console.WriteLine
    - Implement some health checks
4. Performance
    - Message batching and proper resource disposal 
5. Encryption
    - Add message encryption


## Getting started

1. Ensure you have Kafka running locally (default: localhost:9092). Use the provided Docker Compose file if needed.
2. Clone this repo
3. Run the application 'dotnet run'
4. Use the Swagger UI (or Postman) to send messages through "Try it out"
5. Watch the console for consumer output.

Thank you for the great conversation today!

 Best regards,
 Arber Mulolli

 Note: This code is for a demonstration purpose and is not production ready :) 