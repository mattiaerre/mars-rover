using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST.Domain.Rover_Test
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

      _rover = new Rover(position, maxCoordinates);
    }

    [Test]
    public void Coordinates_Fom_00_To_01_When_Command_F()
    {
      _rover.Move(new List<Command> { Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_10_When_Command_RF()
    {
      _rover.Move(new List<Command> { Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_1000_When_Command_LF()
    {
      _rover.Move(new List<Command> { Command.L, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(100, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_0100_When_Command_RRF()
    {
      _rover.Move(new List<Command> { Command.R, Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(100, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_0100_When_Command_B()
    {
      _rover.Move(new List<Command> { Command.B });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(100, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_11_When_Command_FRF()
    {
      _rover.Move(new List<Command> { Command.F, Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_11_When_Command_RFLF()
    {
      _rover.Move(new List<Command> { Command.R, Command.F, Command.L, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_00_When_Command_FRFRFRF()
    {
      _rover.Move(new List<Command> { Command.F, Command.R, Command.F, Command.R, Command.F, Command.R, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void Coordinates_Fom_00_To_00_When_Command_RFLFLFLF()
    {
      _rover.Move(new List<Command> { Command.R, Command.F, Command.L, Command.F, Command.L, Command.F, Command.L, Command.F });

      var position = _rover.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }
  }
}