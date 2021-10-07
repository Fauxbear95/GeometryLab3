using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.Particles;
using Psim.ModelComponents;

namespace Lab3UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddPhonon()
        {
            //create cell, create phonon
            Cell c = new Cell(60, 50);
            Phonon p = new Phonon(1);

            //add phonon to cell
            c.AddPhonon(p);

            //check if there is 1 phonon in the cell 
            Assert.IsTrue(c.phonons.Count == 1);
            Assert.IsInstanceOfType(c.phonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void AddIncPhonon()
        {
            Cell c = new Cell(50, 60);
            Phonon p = new Phonon(1);

            c.AddIncPhonon(p);

            Assert.IsTrue(c.incomingPhonons.Count == 1);
            Assert.IsInstanceOfType(c.incomingPhonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void MergePhonon()
        {
            Cell c = new Cell(100, 100);
            Phonon p = new Phonon(1);

            c.AddIncPhonon(p);
            c.MergeIncPhonons();

            Assert.IsTrue(c.phonons.Count == 1);
            Assert.IsTrue(c.incomingPhonons.Count == 0);
            Assert.IsInstanceOfType(c.phonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void HandlingPhonon()
        {
            Cell c = new Cell(100, 100);

            Phonon p = new Phonon(1);

            BoundarySurface bs = new BoundarySurface(SurfaceLocation.top, c);
            p.SetDirection(1, 1);
            c = bs.HandlePhonon(p);
            Assert.IsTrue(p.Direction.DX == 1 && p.Direction.DY == -1);

            bs = new BoundarySurface(SurfaceLocation.right, c);
            p.SetDirection(1, 1);
            c = bs.HandlePhonon(p);
            Assert.IsTrue(p.Direction.DX == -1 && p.Direction.DY == 1);

            bs = new BoundarySurface(SurfaceLocation.bot, c);
            p.SetDirection(1, 1);
            c = bs.HandlePhonon(p);
            Assert.IsTrue(p.Direction.DX == 1 && p.Direction.DY == -1);

            bs = new BoundarySurface(SurfaceLocation.left, c);
            p.SetDirection(1, 1);
            c = bs.HandlePhonon(p);
            Assert.IsTrue(p.Direction.DX == -1 && p.Direction.DY == 1);
        }
    }
}
