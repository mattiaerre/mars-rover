using System.Collections.Generic;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public class Rover : IRover
  {
    private readonly PositionModel _position;

    public Rover(PositionModel position)
    {
      _position = position;
    }

    public void Commands(List<Command> commands)
    {
      foreach (var command in commands)
        UpdatePosition(command);
    }

    private void UpdatePosition(Command command)
    {
      UpdateOrientation(command);
    }

    private void UpdateOrientation(Command command)
    {
      if (_position.Orientation == Orientation.N && command == Command.R)
        _position.Orientation = Orientation.E;
      else if (_position.Orientation == Orientation.N && command == Command.L)
        _position.Orientation = Orientation.W;
      else if (_position.Orientation == Orientation.E && command == Command.R)
        _position.Orientation = Orientation.S;
      else if (_position.Orientation == Orientation.E && command == Command.L)
        _position.Orientation = Orientation.N;
      else if (_position.Orientation == Orientation.S && command == Command.R)
        _position.Orientation = Orientation.W;
      else if (_position.Orientation == Orientation.S && command == Command.L)
        _position.Orientation = Orientation.E;
      else if (_position.Orientation == Orientation.W && command == Command.R)
        _position.Orientation = Orientation.N;
      else if (_position.Orientation == Orientation.W && command == Command.L)
        _position.Orientation = Orientation.S;
    }

    public PositionModel GetPosition()
    {
      return _position;
    }
  }
}