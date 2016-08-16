#! /bin/sh

# Change this the name of your project. This will be the name of the final executables as well.
project="PierceRealityAutoBuild"

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
  -quit


echo 'Logs from build'
cat $(pwd)/unity.log


