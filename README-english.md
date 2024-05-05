# Tears
## The idea
I made this small program as a concept test for a console game, based on the idea of displaying successive state changes of a string matrix using the Console.WriteLine and Console.Clear methods from a repetition structure controlled by a time delay. It was also a practical way to learn more about the C# language.

## The game
You need to cross the rain of tears and reach the top. There are no applause for this, nor end of the game.

## Compilation
To compile into a self-sufficient executable, access the game directory through the terminal and execute the command corresponding to your operating system:

### Windows:
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

### Linux
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true

### Mac Os
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true

## Do whatever you want with this code! Leave comments and suggestions.
