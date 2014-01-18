using System.Collections.Generic;
using System.Linq;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public class Rover : IRover
  {
    private readonly PositionModel _position;
    private readonly CoordinatesModel _maxCoordinates;
    private readonly List<CoordinatesModel> _obstacles;

    public Rover(PositionModel position, CoordinatesModel maxCoordinates)
      : this(position, maxCoordinates, null)
    {
    }

    public Rover(PositionModel position, CoordinatesModel maxCoordinates, List<CoordinatesModel> obstacles)
    {
      _position = position;
      _maxCoordinates = maxCoordinates;
      _obstacles = obstacles;
      ObstacleFound = false;
    }

    public void Move(List<Command> commands)
    {
      foreach (var command in commands)
        if (!ObstacleFound)
          UpdatePosition(command);
        else
          return;
    }

    private void UpdatePosition(Command command)
    {
      if (command == Command.F || command == Command.B)
        UpdateCoordinates(command);
      if (command == Command.R || command == Command.L)
        UpdateOrientation(command);
    }

    private void UpdateCoordinates(Command command)
    {
      var coordinates = new CoordinatesModel { X = _position.Coordinates.X, Y = _position.Coordinates.Y };

      if (_position.Orientation == Orientation.N && command == Command.F)
        coordinates.Y = coordinates.Y + 1;
      else if (_position.Orientation == Orientation.N && command == Command.B)
        coordinates.Y = coordinates.Y - 1;

      else if (_position.Orientation == Orientation.E && command == Command.F)
        coordinates.X = coordinates.X + 1;
      else if (_position.Orientation == Orientation.E && command == Command.B)
        coordinates.X = coordinates.X - 1;

      else if (_position.Orientation == Orientation.S && command == Command.F)
        coordinates.Y = coordinates.Y - 1;
      else if (_position.Orientation == Orientation.S && command == Command.B)
        coordinates.Y = coordinates.Y + 1;

      else if (_position.Orientation == Orientation.W && command == Command.F)
        coordinates.X = coordinates.X - 1;
      else if (_position.Orientation == Orientation.W && command == Command.B)
        coordinates.X = coordinates.X + 1;

      ManageWrapping(coordinates);

      if (_obstacles == null || CanMoveTo(coordinates))
      {
        _position.Coordinates.X = coordinates.X;
        _position.Coordinates.Y = coordinates.Y;
      }
      else
        ObstacleFound = true;
    }

    private void ManageWrapping(CoordinatesModel coordinates)
    {
      if (coordinates.X == -1)
        coordinates.X = _maxCoordinates.X;
      if (coordinates.Y == -1)
        coordinates.Y = _maxCoordinates.Y;

      if (coordinates.X == _maxCoordinates.X + 1)
        coordinates.X = 0;
      if (coordinates.Y == _maxCoordinates.Y + 1)
        coordinates.Y = 0;
    }

    private bool CanMoveTo(CoordinatesModel coordinates)
    {
      return !_obstacles.Any(e => e.X == coordinates.X && e.Y == coordinates.Y);
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

    public bool ObstacleFound { get; private set; }
  }
}