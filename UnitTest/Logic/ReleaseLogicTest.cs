using BussinessLogic;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Logic
{
    public class ReleaseLogicTest
    {
        readonly Mock<IReleaseEngine> mockReleaseEngine;
        public ReleaseLogicTest()
        {
            mockReleaseEngine = new Mock<IReleaseEngine>();
        }

        [Fact]
        public void CreateRelease_CreatedSuccessfully_ReturnsReleaseId()
        {
            Release release = new Release()
            {
                ReleaseName = "Test",
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 12, 1),
                SprintStatusId = 1,
                CreatedBy = "user",
                CreatedDate = DateTime.Now
            };

            mockReleaseEngine.Setup(x => x.CreateRelease(release))
                .Returns(1);

            ReleaseLogic releaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            int expected = 1;
            int actual = releaseLogic.CreateRelease(release);

            Assert.Equal(expected, actual);
            mockReleaseEngine.Verify(x => x.CreateRelease(release), Times.Once);
        }

        [Fact]
        public void EditRelease_EditedSuccessfull_returnsRelease()
        {
            var release = CreateSampleRelease();

            mockReleaseEngine.Setup(x => x.EditRelease(release))
                .Returns(true);

            mockReleaseEngine.Setup(x => x.ReleaseExists(release.ReleaseId))
               .Returns(true);

            ReleaseLogic releaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            bool expected = true;
            bool actual = releaseLogic.EditRelease(release);

            Assert.Equal(expected, actual);
            mockReleaseEngine.Verify(x => x.EditRelease(release), Times.Once);
        }

        [Fact]
        public void EditRelease_ReleaseDoesNotExists_ThrowsException()
        {
            var release = CreateSampleRelease();

            mockReleaseEngine.Setup(x => x.EditRelease(release))
                .Returns(true);

            mockReleaseEngine.Setup(x => x.ReleaseExists(release.ReleaseId))
               .Returns(false);

            ReleaseLogic ReleaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            Action act = () => { ReleaseLogic.EditRelease(release); };
            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Release does not exists");

            mockReleaseEngine.Verify(x => x.EditRelease(release), Times.Never);
        }

        [Fact]
        public void GetReleaseById_ReturnsSuccessfull()
        {
            var Release = CreateSampleRelease();
            mockReleaseEngine.Setup(x => x.GetRelease(1))
               .Returns(Release);

            var expected = CreateSampleRelease();

            ReleaseLogic ReleaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            var actual = ReleaseLogic.GetRelease(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteRelease_ReleaseDoesNotExists_ThrowsException()
        {
            var Release = CreateSampleRelease();
            mockReleaseEngine.Setup(x => x.RemoveRelease(Release))
                .Returns(true);

            mockReleaseEngine.Setup(x => x.GetRelease(1))
                .Returns((Release)null);

            ReleaseLogic ReleaseLogic = new ReleaseLogic(mockReleaseEngine.Object);
            Action act = () => { ReleaseLogic.RemoveRelease(Release.ReleaseId); };

            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Release does not exists");

            mockReleaseEngine.Verify(x => x.RemoveRelease(Release), Times.Never);
        }

        [Fact]
        public void DeleteRelease_ReleaseDeleted_ReturnsSuccessfull()
        {
            var Release = CreateSampleRelease();
            mockReleaseEngine.Setup(x => x.RemoveRelease(Release))
                           .Returns(true);

            mockReleaseEngine.Setup(x => x.GetRelease(Release.ReleaseId))
                .Returns(Release);

            ReleaseLogic ReleaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            bool expected = true;
            bool actual = ReleaseLogic.RemoveRelease(Release.ReleaseId);

            Assert.Equal(expected, actual);

            mockReleaseEngine.Verify(x => x.RemoveRelease(Release), Times.Once);
        }

        [Fact]
        public void GetReleases_ReturnsSuccessfull()
        {
            var Release1 = CreateSampleRelease();
            var Release2 = CreateSampleRelease(2);
            List<Release> Releaseobj = new List<Release>();
            Releaseobj.Add(Release1);
            Releaseobj.Add(Release2);

            mockReleaseEngine.Setup(x => x.GetReleaseList())
               .Returns(Releaseobj);

            var expected = Releaseobj;

            ReleaseLogic ReleaseLogic = new ReleaseLogic(mockReleaseEngine.Object);

            var actual = ReleaseLogic.GetReleaseList();

            Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        private Release CreateSampleRelease(int releaseId = 1)
        {
            Release release = new Release()
            {
                ReleaseId = releaseId,
                ReleaseName = "test1",
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 12, 1),
                SprintStatusId = 1,
                CreatedBy = "user",
                CreatedDate = new DateTime(2019, 12, 30)
            };
            return release;
        }

    }
}
