# NotificationService

Another view for multi-channel notification service.
Allows clients to send notifications via a single HTTP endpoint (or schedule them with delay) — supporting Email, SMS, and Push notifications.

## Features

- Unified HTTP API endpoint to submit notifications (sync or async)  
- Multi-channel support: Email, SMS, Push  
- Provide easy way of adding new Email and SMS providers
- Optional scheduling / delayed delivery  
- Clean, extensible architecture: you can add new notification channels/providers easily  
- Background processing of notifications (queue / worker style)  (Todo)

## Project Structure

- Minimal Api 
- Single Assembly Clean Architecture