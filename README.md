# WebApplicationTimer

This .NET 8.0 Web API allows you to create persistent timers that trigger webhooks after a specified duration. The API includes two endpoints: `Set Timer` and `Get Timer Status`.

## Features

- **Set Timer:** Create a timer that will trigger a webhook after a specified duration.
- **Get Timer Status:** Check the remaining time for an active timer.
- **Persistent Timers:** Timers continue running across server restarts and will trigger webhooks as expected.
- **SQLite Database:** Used to store timer information, ensuring persistence.

## Requirements

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQLite database (handled by Entity Framework Core)

## Setup and Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/WebApplicationTimer.git
   cd TimerServiceAPI
   ```

2. Install required packages:

   ```bash
   dotnet restore
   ```

3. Run the Entity Framework migrations to set up the SQLite database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Running the API

Start the API server using the following command:

```bash
dotnet run
```

## API Endpoints

1. Set Timer
   Endpoint: POST /api/Timers/SetTimer

Description: Sets a timer that triggers a webhook after the specified duration.

Request Body: JSON object with the following fields:
{
"hours": 0,
"minutes": 0,
"seconds": 30,
"url": "https://your-webhook-url.com"
}

Response: JSON object with the id field representing the unique identifier of the timer.
{
"id": "unique-timer-id"
}

Example Request:
curl -X POST "https://localhost:5055/api/Timers/SetTimer" -H "Content-Type: application/json" -d "{\"hours\":0,\"minutes\":0,\"seconds\":30,\"webhookurl\":\"https://your-webhook-url.com\"}"

2. Get Timer Status
   Endpoint: GET /api/Timers/GetTimerStatus/{id}

Description: Retrieves the number of seconds remaining until the timer expires.

Path Parameter:

id: Unique identifier for the timer.
Response: JSON object with the secondsLeft field, which is 0 if the timer has expired.
{
"secondsLeft": 25
}

Example Request:
curl -X GET "https://localhost:5055/api/Timers/GetTimerStatus/unique-timer-id"

## Additional Information

Timer Persistence
Timers are stored in an SQLite database, which ensures they persist across server restarts. On startup, the background service checks for any expired timers and sends the necessary webhook notifications.

Handling Webhooks
When a timer expires, a POST request with an empty body is sent to the specified URL. You may need to configure the webhook endpoint to handle these incoming requests.

Project Structure
The API follows a simple structure:

Controllers: Contains the API controllers.
Models: Defines the Timer model.
Repository: Contains the TimerContext for Entity Framework Core.
Services: Includes the TimerBackgroundService to handle timer execution.

Contact
For any questions or issues, please contact artem.bc@gmail.com.com.
