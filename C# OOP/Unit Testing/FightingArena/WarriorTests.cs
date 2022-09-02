using System;
namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        public Warrior firstWarrior;
        public Warrior secondWarrior;
        [SetUp]
        public void SetUp()
        {
            firstWarrior = new Warrior("Zed", 60, 200);
            secondWarrior = new Warrior("Yasuo", 50, 150);


        }
        [Test]
        public void Test_If_Constuctor_Assigns_Properties()
        {
            Assert.That(firstWarrior.Name == "Zed" && firstWarrior.Damage == 60 && firstWarrior.HP == 200 && secondWarrior.Name == "Yasuo" && secondWarrior.Damage == 50 && secondWarrior.HP == 150);


        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Check_If_Exception_Is_Thrown_When_Name_Is_Null_Or_Empty_or_WhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 60, 100));


        }
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Check_If_Exception_Is_Thrown_When_Damage_Is_Lower_Or_Equal_To_Zero(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", damage, 200));


        }
        [Test]
        [TestCase(-10)]
        public void Check_If_Exception_Is_Thrown_When_HP_Is_Negative(int HP)
        {

            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", 100, HP));

        }
        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Check_If_Exception_Is_Thrown_When_Attackers_HP_Is_Lower_Or_Equal_To_MIN_ATTACK_HP(int HP)
        {
            Warrior warrior = new Warrior("sdfsd", 30, HP);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(firstWarrior));


        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Check_If_Exception_Is_Thrown_When_The_Attacked_Warriors_HP_Is_Lower_Or_Equal_To_MIN_ATTACK_HP(int HP)
        {
            Warrior warrior = new Warrior("sdfsd", 30, HP);
            Assert.Throws<InvalidOperationException>(() => firstWarrior.Attack(warrior));


        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_Trying_To_Attack_A_Stronger_Enemy()
        {
            Warrior warrior = new Warrior("slabak", 20, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(firstWarrior));

        }
        [Test]
        public void Check_If_Current_HP_Is_Lowered_When_Attacked_Enemy()
        {
            firstWarrior.Attack(secondWarrior);
            Assert.AreEqual(150, firstWarrior.HP);


        }
        [Test]
        public void Check_If_Enemy_HP_Is_Lowered_When_Attacked()
        {
            firstWarrior.Attack(secondWarrior);
            Assert.AreEqual(90, secondWarrior.HP);


        }
        [Test]
        public void Check_If_Enemy_Hp_Is_Assigned_To_Zero_When_Killed()
        {
            Warrior warrior = new Warrior("slabak", 20, 50);
            firstWarrior.Attack(warrior);
            Assert.AreEqual(0, warrior.HP);


        }
    }
}