using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Avalon.Common;
using Moq;
using NUnit.Framework;

namespace Avalon.Tests
{
    [TestFixture]
    class MainWindowViewModelTests
    {

        [Test]
        public void FirstModuleShouldBeSelectedByDefault()
        {
            IModule module = new Mock<IModule>().Object;
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] {module});
            Assert.AreSame(vm.SelectedModule, module);
        }

        [Test]
        [RequiresSTA]
        public void ShowsUserInterfaceOfSelectedModule()
        {
            var mock = new Mock<IModule>();
            var ui = new Mock<UserControl>();
            mock.Setup(m => m.UserInterface).Returns(ui.Object);
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { mock.Object });
            Assert.AreSame(ui.Object, vm.UserInterface);
        }

        [Test]
        public void IfNoModulesUserInterfaceReturnsNull()
        {
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] {});
            Assert.IsNull(vm.UserInterface);
        }

        [Test]
        public void WhenSelectedModuleChangesPropertyChangedEventFires()
        {
            var module = new Mock<IModule>().Object;
            var module2 = new Mock<IModule>().Object;
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] {module, module2});
            List<string> propertiesChanged = new List<string>();
            vm.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            vm.SelectedModule = vm.Modules[1];

            Assert.AreEqual(2, propertiesChanged.Count);
            Assert.IsTrue(propertiesChanged.Contains("SelectedModule"));
            Assert.IsTrue(propertiesChanged.Contains("UserInterface"));
        }
    }
}
