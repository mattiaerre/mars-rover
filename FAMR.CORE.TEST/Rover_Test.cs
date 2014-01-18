using System.Collections.Generic;
using FAMR.CORE.Domain;
using FAMR.CORE.Models;
using NUnit.Framework;

namespace FAMR.CORE.TEST
{
  [TestFixture]
  public class Rover_Test
  {
    private IRover _rover;

    [SetUp]
    public void Given_A_Rover()
    {
      var position = new PositionModel { X = 0, Y = 0, Orientation = Orientation.N };

      _rover = new Rover(position);
    }

    [Test]
    public void Orientatio_Fom_N_To_E_When_Command_R()
    {
      _rover.Commands(new List<Command> { Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.E, position.Orientation);
    }

    [Test]
    public void Orientatio_Fom_N_To_W_When_Command_L()
    {
      _rover.Commands(new List<Command> { Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.W, position.Orientation);
    }

    [Test]
    public void Orientatio_Fom_N_To_S_When_Command_RR()
    {
      _rover.Commands(new List<Command> { Command.R, Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void Orientatio_Fom_N_To_S_When_Command_LL()
    {
      _rover.Commands(new List<Command> { Command.L, Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void Orientatio_Fom_N_To_N_When_Command_LLLL()
    {
      _rover.Commands(new List<Command> { Command.L, Command.L, Command.L, Command.L });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test]
    public void Orientatio_Fom_N_To_N_When_Command_RRRR()
    {
      _rover.Commands(new List<Command> { Command.R, Command.R, Command.R, Command.R });

      var position = _rover.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test, Explicit]
    public void Start_00N_Command_F_End_01N()
    {
      // arrange
      var commands = new List<Command> { Command.F };

      // act
      _rover.Commands(commands);

      // asser
      var result = _rover.GetPosition();

      Assert.AreEqual(0, result.X);
      Assert.AreEqual(1, result.X);
      Assert.AreEqual(Orientation.N, result.Orientation);
    }

    [Test, Explicit]
    public void Start_00E_Command_F_End_10E()
    {
      // arrange
      var commands = new List<Command> { Command.F };

      // act
      _rover.Commands(commands);

      // asser
      var result = _rover.GetPosition();

      Assert.AreEqual(1, result.X);
      Assert.AreEqual(0, result.X);
      Assert.AreEqual(Orientation.E, result.Orientation);
    }
  }
}
