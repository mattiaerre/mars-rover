using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST.Domain.Rover_Test
{
  [TestFixture]
  public class Rover_Orientation_Test
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
    public void Orientation_Fom_N_To_E_When_Command_R()
    {
      _rover.Move(new List<Command> { Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.E, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_S_When_Command_RR()
    {
      _rover.Move(new List<Command> { Command.R, Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_W_When_Command_RRR()
    {
      _rover.Move(new List<Command> { Command.R, Command.R, Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.W, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_N_When_Command_RRRR()
    {
      _rover.Move(new List<Command> { Command.R, Command.R, Command.R, Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_W_When_Command_L()
    {
      _rover.Move(new List<Command> { Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.W, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_S_When_Command_LL()
    {
      _rover.Move(new List<Command> { Command.L, Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_E_When_Command_LLL()
    {
      _rover.Move(new List<Command> { Command.L, Command.L, Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.E, position.Orientation);
    }

    [Test]
    public void Orientation_Fom_N_To_N_When_Command_LLLL()
    {
      _rover.Move(new List<Command> { Command.L, Command.L, Command.L, Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }
  }
}