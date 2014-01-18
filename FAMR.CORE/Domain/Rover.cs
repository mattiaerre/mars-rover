using System.Collections.Generic;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public class Rover : IRover
  {
    private readonly PositionModel _position;
    private readonly CoordinatesModel _maxCoordinates;

    public Rover(PositionModel position, CoordinatesModel maxCoordinates)
    {
      _position = position;
      _maxCoordinates = maxCoordinates;
    }

    public void Commands(List<Command> commands)
    {
      foreach (var command in commands)
        UpdatePosition(command);
    }

    private void UpdatePosition(Command command)
    {
      UpdateCoordinates(command);
      UpdateOrientation(command);
    }

    private void UpdateCoordinates(Command command)
    {
      if (_position.Orientation == Orientation.N && command == Command.F)
        _position.Coordinates.Y = _position.Coordinates.Y + 1;
      else if (_position.Orientation == Orientation.N && command == Command.B)
        _position.Coordinates.Y = _position.Coordinates.Y - 1;

      else if (_position.Orientation == Orientation.E && command == Command.F)
        _position.Coordinates.X = _position.Coordinates.X + 1;
      else if (_position.Orientation == Orientation.E && command == Command.B)
        _position.Coordinates.X = _position.Coordinates.X - 1;

      else if (_position.Orientation == Orientation.S && command == Command.F)
        _position.Coordinates.Y = _position.Coordinates.Y - 1;
      else if (_position.Orientation == Orientation.S && command == Command.B)
        _position.Coordinates.Y = _position.Coordinates.Y + 1;

      else if (_position.Orientation == Orientation.W && command == Command.F)
        _position.Coordinates.X = _position.Coordinates.X - 1;
      else if (_position.Orientation == Orientation.W && command == Command.B)
        _position.Coordinates.X = _position.Coordinates.X + 1;

      if (_position.Coordinates.X == -1)
        _position.Coordinates.X = _maxCoordinates.X;
      if (_position.Coordinates.Y == -1)
        _position.Coordinates.Y = _maxCoordinates.Y;
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