# Contoso MCP Server

This project is a simple C# server implementing the Model Context Protocol (MCP). It serves as an example for the fictitious Microsoft Contoso product company, demonstrating how to build an MCP server using the official [MCP C# SDK](docs/csharp_mcp_sdk.md).

## Project Layout

The project is structured as follows:

- `ContosoMcp.sln`: The main solution file for Visual Studio.
- `README.md`: This file.
- `docs/`: Contains documentation related to the project and the MCP C# SDK.
  - `csharp_mcp_sdk.md`: Detailed documentation for the MCP C# SDK.
- `src/`: Contains the source code for the MCP server.
  - `ContosoMcpServer/`: The C# project for the MCP server.
    - `ContosoMcpServer.csproj`: The project file, defining dependencies and build settings.
    - `Program.cs`: The main entry point for the server application.
    - `Tools/`: Contains custom tools exposed by the MCP server.
      - `WeatherTools.cs`: An example of a tool (e.g., for fetching weather information).
- `bin/`: Contains compiled binaries after building the project.
- `obj/`: Contains intermediate files generated during the build process.

## Prerequisites

To build and run this project, you will need:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or a compatible version). The project appears to target .NET 9 based on the build output paths.

## Getting Started

### 1. Clone the Repository

If you haven't already, clone this repository to your local machine.

### 2. Install Dependencies

Navigate to the root directory of the project in your terminal and run the following command to restore the necessary NuGet packages, including the `ModelContextProtocol` SDK:

```bash
dotnet restore ContosoMcp.sln
```

Alternatively, you can navigate to the server project directory:

```bash
cd src/ContosoMcpServer
dotnet restore
cd ../..
```

### 3. Build the Project

Once dependencies are installed, you can build the project using:

```bash
dotnet build ContosoMcp.sln --configuration Release
```

Or, to build the server project specifically:

```bash
dotnet build src/ContosoMcpServer/ContosoMcpServer.csproj --configuration Release
```

### 4. Run the Server

After a successful build, you can run the MCP server:

```bash
dotnet run --project src/ContosoMcpServer/ContosoMcpServer.csproj
```

The server will start and listen for MCP client connections as configured in `Program.cs`.

### 5. Using with GitHub Copilot (VS Code)

This project includes a `.vscode/mcp.json` file that allows you to easily run the `ContosoMcpServer` and make its tools available to GitHub Copilot within Visual Studio Code.

1. **Ensure VS Code is Restarted (if needed)**: If VS Code was open when the `.vscode/mcp.json` file was first created or significantly changed, it's good practice to restart VS Code to ensure it recognizes the MCP server configuration.

2. **Start the MCP Server via VS Code**:

   - Open the `.vscode/mcp.json` file in VS Code.
   - You should see a "ContosoMcpServer" entry. Above this entry, a **"Start"** button will appear.
   - Click this "Start" button. This action executes the `dotnet run --project src/ContosoMcpServer/ContosoMcpServer.csproj` command, launching your C# MCP server.
   - Output from the server will appear in the VS Code terminal.

3. **Enable Agent Mode in Copilot Chat**:

   - Open the GitHub Copilot Chat view (usually found as an icon in the activity bar or via the command palette).
   - In the chat input area, ensure that Copilot is set to **"Agent"** mode. This mode allows Copilot to utilize tools from connected MCP servers. There might be a dropdown menu or a specific command (`@agent` or similar) to switch to this mode.

4. **Verify Tool Discovery**:
   - Once in Agent mode, look for an icon (often resembling a wrench, plug, or tools) near the chat input box. Clicking this icon should display a list of available agents or tools.
   - You should see "ContosoMcpServer" listed. If you expand it or query Copilot, it should be aware of the tools defined in `src/ContosoMcpServer/Tools/WeatherTools.cs` (e.g., `GetCurrentWeatherAsync`, `GetWeatherForecastAsync`).

Now, when you interact with GitHub Copilot Chat in Agent mode, it can leverage the custom tools provided by your `ContosoMcpServer`. For example, you could ask Copilot: "@ContosoMcpServer what is the current weather in London, UK?".

## About MCP

The Model Context Protocol (MCP) is an open protocol that standardizes how applications provide context to Large Language Models (LLMs). It enables secure integration between LLMs and various data sources and tools.

For more information about MCP:

- [Official MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Protocol Specification](https://spec.modelcontextprotocol.io/)
- [MCP C# SDK Documentation (included in this project)](docs/csharp_mcp_sdk.md)
- [MCP C# SDK on NuGet](https://www.nuget.org/packages/ModelContextProtocol/)
