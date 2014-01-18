using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST.Domain.Rover_Test
{
  [TestFixture]
  public class Rover_Obstacle_Detection_Test
  {
    private IRover _rover;
    private CoordinatesModel _maxCoordinates;

    [SetUp]
    public void Given_A_Rover()
    {
      var position = new PositionModel { Coordinates = new CoordinatesModel { X = 0, Y = 0 }, Orientation = Orientation.N };
      _maxCoordinates = new CoordinatesModel { X = 100, Y = 100 };
      var obstacles = new List<CoordinatesModel> { new CoordinatesModel { X = 1, Y = 1 } };

      _rover = new Rover(position, _maxCoordinates, obstacles);
    }

    [Test]
    public void Position_From_00N_To_01E_When_Command_FRF_And_Obstacle_In_11()
    {
      var commands = new List<Command> { Command.F, Command.R, Command.F };

      _rover.Move(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(0, result.Coordinates.X);
      Assert.AreEqual(1, result.Coordinates.Y);
      Assert.AreEqual(Orientation.E, result.Orientation);

      Assert.IsTrue(_rover.ObstacleFound);
    }

    [Test]
    public void Position_From_11S_To_10W_When_Command_FRF_And_Obstacle_In_00()
    {
      var position = new PositionModel { Coordinates = new CoordinatesModel { X = 1, Y = 1 }, Orientation = Orientation.S };
      var obstacles = new List<CoordinatesModel> { new CoordinatesModel { X = 0, Y = 0 } };

      var rover = new Rover(position, _maxCoordinates, obstacles);

      var commands = new List<Command> { Command.F, Command.R, Command.F };

      rover.Move(commands);

      var result = rover.GetPosition();

      Assert.AreEqual(1, result.Coordinates.X);
      Assert.AreEqual(0, result.Coordinates.Y);
      Assert.AreEqual(Orientation.W, result.Orientation);

      Assert.IsTrue(rover.ObstacleFound);
    }

    [Test]
    public void Position_From_20N_To_21N_When_Command_FFRF_And_Obstacle_In_22()
    {
      var obstacles = new List<CoordinatesModel> { new CoordinatesModel { X = 2, Y = 2 } };

      var rover = new Rover(
        new PositionModel { Coordinates = new CoordinatesModel { X = 2, Y = 0 }, Orientation = Orientation.N },
        new CoordinatesModel { X = 3, Y = 3 },
        obstacles);

      rover.Move(new List<Command>{ Command.F, Command.F, Command.R, Command.F });

      var position = rover.GetPosition();

      Assert.AreEqual(2, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
      Assert.AreEqual(Orientation.N, position.Orientation);

      Assert.IsTrue(rover.ObstacleFound);
    }

    [Test]
    public void Position_From_20N_To_21N_When_Command_FFRFFF_And_Obstacle_In_22()
    {
      var obstacles = new List<CoordinatesModel> { new CoordinatesModel { X = 2, Y = 2 } };

      var rover = new Rover(
        new PositionModel { Coordinates = new CoordinatesModel { X = 2, Y = 0 }, Orientation = Orientation.N },
        new CoordinatesModel { X = 3, Y = 3 },
        obstacles);

      rover.Move(new List<Command> { Command.F, Command.F, Command.R, Command.F, Command.F, Command.F });

      var position = rover.GetPosition();

      Assert.AreEqual(2, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
      Assert.AreEqual(Orientation.N, position.Orientation);

      Assert.IsTrue(rover.ObstacleFound);
    }
  }
}
