﻿using System.Collections.Generic;
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
      var position = new PositionModel { Coordinates = new CoordinatesModel { X = 0, Y = 0 }, Orientation = Orientation.N };
      var maxCoordinates = new CoordinatesModel { X = 100, Y = 100 };

      _rover = new Rover(position, maxCoordinates);
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
  }
}
