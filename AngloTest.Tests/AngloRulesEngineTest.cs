using System;
using System.Collections.Generic;
using AngloTest.Models;
using AngloTest.RulesEngine.Classes;
using AngloTest.RulesEngine.Interfaces;
using NUnit.Framework;

namespace AngloTest.Tests
{
    public class AngloRulesEngineTest
    {
        private IRulesEngine _rulesEngine;
        
        [SetUp]
        public void Setup()
        {
            _rulesEngine = new RuleEngine();
        }

        [Test]
        public void ValidData_Returns_True()
        {
            //arrange
            var data = new List<AngloData>()
            {
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "12",
                    AccountType = "facebook",
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }, 
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "15",
                    AccountType = "twitter",
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }
            };
            
            //act
            var result = _rulesEngine.IsValid(data);
            
            //assert
            Assert.AreEqual(true, result);
        }
        
        [Test]
        public void EmptyAccountType_Returns_False()
        {
            //arrange
            var data = new List<AngloData>()
            {
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "12",
                    AccountType = "facebook",
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }, 
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "15",
                    AccountType = String.Empty,
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }
            };
            
            //act
            var result = _rulesEngine.IsValid(data);
            
            //assert
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void NanAge_Returns_False()
        {
            //arrange
            var data = new List<AngloData>()
            {
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "Help",
                    AccountType = "facebook",
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }, 
                new AngloData()
                {
                    Id = Guid.NewGuid(),
                    Age = "15",
                    AccountType = String.Empty,
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }
            };
            
            //act
            var result = _rulesEngine.IsValid(data);
            
            //assert
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void Duplicate_Data_Returns_False()
        {
            //arrange
            var id = Guid.NewGuid();
            var accountType = "facebook";
            
            var data = new List<AngloData>()
            {
                new AngloData()
                {
                    Id = id,
                    Age = "18",
                    AccountType = accountType,
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }, 
                new AngloData()
                {
                    Id = id,
                    Age = "18",
                    AccountType = accountType,
                    BirthDay = DateTime.Today,
                    SignupDate = DateTime.Today
                }
            };
            
            //act
            var result = _rulesEngine.IsValid(data);
            
            //assert
            Assert.AreEqual(false, result);
        }
    }
}