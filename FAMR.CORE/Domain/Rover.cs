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
      _position.Orientation = Orientation.E;
    }

    public PositionModel GetPosition()
    {
      return _position;
    }
  }
}