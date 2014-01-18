using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      _rover = new Rover();

    }

    [Test]
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

    [Test]
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
