using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST.Domain.Rover
{
  [TestFixture]
  public class Rover_Coordinates_Test
  {
    private IRover _rover;

    [SetUp]
    public void Given_A_Rover()
    {
      var position = new PositionModel { Coordinates = new CoordinatesModel { X = 0, Y = 0 }, Orientation = Orientation.N };
      var maxCoordinates = new CoordinatesModel { X = 100, Y = 100 };

      _rover = new CORE.Domain.Rover(position, maxCoordinates);
    }

    [Test]
    public void Coordinates_Fom_00_To_01_When_Command_F()
    {
      _rover.Commands(new List<Command> { Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_10_When_Command_RF()
    {
      _rover.Commands(new List<Command> { Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_11_When_Command_FRF()
    {
      _rover.Commands(new List<Command> { Command.F, Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_11_When_Command_RFLF()
    {
      _rover.Commands(new List<Command> { Command.R, Command.F, Command.L, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_00_When_Command_FRFRFRF()
    {
      _rover.Commands(new List<Command> { Command.F, Command.R, Command.F, Command.R, Command.F, Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_00_When_Command_RFLFLFLF()
    {
      _rover.Commands(new List<Command> { Command.R, Command.F, Command.L, Command.F, Command.L, Command.F, Command.L, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }
  }
}