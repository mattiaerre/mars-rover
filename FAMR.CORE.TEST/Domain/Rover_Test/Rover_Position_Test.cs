using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST.Domain.Rover_Test
{
  [TestFixture]
  public class Rover_Position_Test
  {
    private IRover _rover;
    private CoordinatesModel _maxCoordinates;

    [SetUp]
    public void Given_A_Rover()
    {
      var position = new PositionModel { Coordinates = new CoordinatesModel { X = 0, Y = 0 }, Orientation = Orientation.N };
      _maxCoordinates = new CoordinatesModel { X = 100, Y = 100 };

      _rover = new Rover(position, _maxCoordinates);
    }

    [Test]
    public void Position_From_00N_To_01N_When_Command_F()
    {
      var commands = new List<Command> { Command.F };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(0, result.Coordinates.X);
      Assert.AreEqual(1, result.Coordinates.Y);
      Assert.AreEqual(Orientation.N, result.Orientation);
    }

    [Test]
    public void Position_From_00N_To_10E_When_Command_RF()
    {
      var commands = new List<Command> { Command.R, Command.F };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(1, result.Coordinates.X);
      Assert.AreEqual(0, result.Coordinates.Y);
      Assert.AreEqual(Orientation.E, result.Orientation);
    }

    [Test]
    public void Position_From_00N_To_0100N_When_Command_B()
    {
      var commands = new List<Command> { Command.B };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(0, result.Coordinates.X);
      Assert.AreEqual(100, result.Coordinates.Y);
      Assert.AreEqual(Orientation.N, result.Orientation);
    }

    [Test]
    public void Position_From_00N_To_1000E_When_Command_RB()
    {
      var commands = new List<Command> { Command.R, Command.B };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(100, result.Coordinates.X);
      Assert.AreEqual(0, result.Coordinates.Y);
      Assert.AreEqual(Orientation.E, result.Orientation);
    }

    [Test]
    public void Position_From_00N_To_100100N_When_Command_RBLB()
    {
      var commands = new List<Command> { Command.R, Command.B, Command.L, Command.B };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(100, result.Coordinates.X);
      Assert.AreEqual(100, result.Coordinates.Y);
      Assert.AreEqual(Orientation.N, result.Orientation);
    }

    [Test]
    public void Position_From_00N_To_22E_When_Command_FFRFF()
    {
      var commands = new List<Command> { Command.F, Command.F, Command.R, Command.F, Command.F };

      _rover.Commands(commands);

      var result = _rover.GetPosition();

      Assert.AreEqual(2, result.Coordinates.X);
      Assert.AreEqual(2, result.Coordinates.Y);
      Assert.AreEqual(Orientation.E, result.Orientation);
    }

    [Test]
    public void Position_From_100100N_To_00E_When_Command_FRF()
    {
      var rover =
        new Rover(new PositionModel { Coordinates = new CoordinatesModel { X = 100, Y = 100 }, Orientation = Orientation.N },
          _maxCoordinates);

      rover.Commands(new List<Command> { Command.F, Command.R, Command.F });

      var position = rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);

      Assert.AreEqual(Orientation.E, position.Orientation);
    }
    
    [Test]
    public void Position_Fom_0100N_To_00N_When_Command_F()
    {
      var rover =
        new Rover(new PositionModel { Coordinates = new CoordinatesModel { X = 0, Y = 100 }, Orientation = Orientation.N },
          _maxCoordinates);

      rover.Commands(new List<Command> { Command.F });

      var position = rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);

      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test]
    public void Position_Fom_1000E_To_00E_When_Command_F()
    {
      var rover =
        new Rover(new PositionModel { Coordinates = new CoordinatesModel { X = 100, Y = 0 }, Orientation = Orientation.E },
          _maxCoordinates);

      rover.Commands(new List<Command> { Command.F });

      var position = rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);

      Assert.AreEqual(Orientation.E, position.Orientation);
    }
  }
}
