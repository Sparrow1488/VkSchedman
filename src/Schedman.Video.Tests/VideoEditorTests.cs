using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using VkSchedman.Video;
using VkSchedman.Video.Abstractions;
using VkSchedman.Video.Enum;
using VkSchedman.Video.Options;

namespace Schedman.Video.Tests
{
    [TestClass]
    public class VideoEditorTests
    {
        public VideoEditorTests()
        {
            _input = new InputOptions();
            _input.AddSource(_testFilePath);
            _output = new OutputOptions();
            _output.SetOutputPath("C:/Users/aleks/Downloads");
            _output.SetOutputFileName("test-video");
        }

        private IInputOptions _input;
        private IOutputOptions _output;
        private static string _ffmpegPath = @"D:/games/ffmpeg/ffmpeg.exe";
        private static readonly string _testFilePath = @"C:\Users\aleks\Downloads\test-videos-2\3.mp4";

        [TestMethod]
        public async Task ConvertToExtensionTests()
        {
            var editor = new VideoEditor(_ffmpegPath);
            editor.SetOptions(_input);
            editor.SetOptions(_output);
            await editor.ConvertToExtensionAsync(FileExtension.AVI);
            var result = File.Exists(_output.GetResultPath());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetOptions_NullValue_ArgumentNullExceptionReturned()
        {
            var editor = new VideoEditor(_ffmpegPath);
            InputOptions input = null;
            OutputOptions output = null;

            Assert.ThrowsException<ArgumentNullException>(() => editor.SetOptions(input));
            Assert.ThrowsException<ArgumentNullException>(() => editor.SetOptions(output));
        }

        [TestMethod]
        public async Task ConcatFilesTests()
        {
            var editor = new VideoEditor(_ffmpegPath);
            var input = new InputOptions();

            foreach (var source in Directory.GetFiles(@"C:\Users\aleks\Downloads\test-videos"))
                input.AddSource(source);
            editor.SetOptions(input);
            editor.SetOptions(_output);
            await editor.ConcatFilesAsync();
            var path = _output.GetResultPath();
            var exists = File.Exists(path);

            Assert.IsTrue(exists);
        }
    }
}