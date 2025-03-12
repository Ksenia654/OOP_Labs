using ConsolePaintApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PaintApp.Tests
{
    [TestClass]
    public class CanvasTests
    {
        private Canvas? canvas;

        [TestInitialize]
        public void Setup()
        {
            Canvas.IsTesting = true;
            canvas = new Canvas();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Canvas.IsTesting = false;
        }

        [TestMethod]
        public void AddShape_ValidCircle_AddsToCanvas()
        {
            Shape circle = new Circle(5, 5, 3);
            canvas?.AddShape(circle);
            Assert.AreEqual(1, canvas?.GetShapes().Count);
            Assert.AreEqual(circle, canvas?.GetShapes()[0]);
        }

        [TestMethod]
        public void AddShape_ValidSquare_AddsToCanvas()
        {
            Shape square = new Square(10, 10, 4, 6);
            canvas?.AddShape(square);
            Assert.AreEqual(1, canvas?.GetShapes().Count);
            Assert.AreEqual(square, canvas?.GetShapes()[0]);
          //  Assert.AreEqual(4, ((Square)canvas?.GetShapes()?[0])?.Width);
          //  Assert.AreEqual(6, ((Square)canvas?.GetShapes()?[0])?.Size);
        }

        [TestMethod]
        public void AddShape_ValidTriangle_AddsToCanvas()
        {
            Shape triangle = new Triangle(15, 5, 6, 8, 10);
            canvas?.AddShape(triangle);
            Assert.AreEqual(1, canvas?.GetShapes().Count);
            Assert.AreEqual(triangle, canvas?.GetShapes()[0]);
        }

        [TestMethod]
        public void AddShape_OutOfBoundsCircle_DoesNotAdd()
        {
            Shape circle = new Circle(38, 18, 8);
            canvas?.AddShape(circle);
            Assert.AreEqual(0, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void AddShape_AtBoundary_AddsShape()
        {
            Shape triangle = new Triangle(0, 0, 2, 3, 4);
            canvas?.AddShape(triangle);
            Assert.AreEqual(1, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void EraseShape_ValidIndex_RemovesShape()
        {
            Shape circle = new Circle(5, 5, 3);
            canvas?.AddShape(circle);
            canvas?.EraseShape(0);
            Assert.AreEqual(0, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void EraseShape_InvalidIndex_DoesNothing()
        {
            Shape circle = new Circle(5, 5, 3);
            canvas?.AddShape(circle);
            canvas?.EraseShape(1);
            Assert.AreEqual(1, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void MoveShape_ValidMove_UpdatesPosition()
        {
            Shape square = new Square(10, 10, 4, 6);
            canvas?.AddShape(square);
            canvas?.MoveShape(0, 15, 14);
            Assert.AreEqual(15, square.X);
            Assert.AreEqual(14, square.Y);
        }

        [TestMethod]
        public void MoveShape_OutOfBounds_DoesNotMove()
        {
            Shape square = new Square(10, 10, 4, 6);
            canvas?.AddShape(square);
            canvas?.MoveShape(0, 50, 50);
            Assert.AreEqual(10, square.X);
            Assert.AreEqual(10, square.Y);
        }

        [TestMethod]
        public void MoveShape_ToBoundary_MovesShape()
        {
            Shape triangle = new Triangle(10, 10, 3, 4, 5);
            canvas?.AddShape(triangle);
            canvas?.MoveShape(0, 0, 0);
            Assert.AreEqual(0, triangle.X);
            Assert.AreEqual(0, triangle.Y);
        }

        [TestMethod]
        public void SetBackground_ValidIndex_SetsBackground()
        {
            Shape square = new Square(10, 10, 4, 6);
            canvas?.AddShape(square);
            canvas?.SetBackground(0, '#');
            Assert.AreEqual('#', square.BackgroundChar);
        }

        [TestMethod]
        public void SetBackground_InvalidIndex_DoesNothing()
        {
            Shape square = new Square(10, 10, 4, 6);
            canvas?.AddShape(square);
            canvas?.SetBackground(1, '#');
            Assert.AreEqual(' ', square.BackgroundChar);
        }

        [TestMethod]
        public void Undo_AfterAddShape_RemovesShape()
        {
            Shape circle = new Circle(5, 5, 3);
            canvas?.AddShape(circle);
            canvas?.Undo();
            Assert.AreEqual(0, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void Undo_WhenNoActions_DoesNothing()
        {
            canvas?.Undo();
            Assert.AreEqual(0, canvas?.GetShapes().Count);
        }

        [TestMethod]
        public void Redo_AfterUndo_ReAddsShape()
        {
            Shape circle = new Circle(5, 5, 3);
            canvas?.AddShape(circle);
            canvas?.Undo();
            canvas?.Redo();
            Assert.AreEqual(1, canvas?.GetShapes().Count);
            Shape? restoredCircle = canvas?.GetShapes()[0];
            Assert.AreEqual(circle.X, restoredCircle?.X);
            Assert.AreEqual(circle.Y, restoredCircle?.Y);
            Assert.AreEqual(circle.Size, restoredCircle?.Size);
            Assert.AreEqual(circle.FillChar, restoredCircle?.FillChar);
            Assert.AreEqual(circle.BackgroundChar, restoredCircle?.BackgroundChar);
        }

        [TestMethod]
        public void SaveAndLoadCanvas_PreservesShapes()
        {
            Shape circle = new Circle(5, 5, 3);
            Shape triangle = new Triangle(10, 10, 3, 4, 5);
            canvas?.AddShape(circle);
            canvas?.AddShape(triangle);
            string filename = "test_save.txt";
            FileManager fileManager = new FileManager();
            if (canvas != null)
            {
                fileManager.SaveCanvas(canvas, filename);
            }
            Canvas loadedCanvas = new Canvas();
            fileManager.LoadCanvas(loadedCanvas, filename);
            Assert.AreEqual(2, loadedCanvas.GetShapes().Count);
            Assert.IsInstanceOfType(loadedCanvas.GetShapes()[0], typeof(Circle));
            Assert.IsInstanceOfType(loadedCanvas.GetShapes()[1], typeof(Triangle));
        }
    }
}