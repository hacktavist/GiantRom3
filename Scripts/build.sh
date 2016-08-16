#! /bin/sh

# Change this the name of your project. This will be the name of the final executables as well.
project="PierceRealityAutoBuild"

echo 'Attempting to build $project for Windows'
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
#C:/Program\ Files/Unity/Editor/Unity.exe \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath "$(pwd)" \
  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
  -quit

sleep 1m


FILENAME="$(pwd)PierceRealityWindowsBuild"
mv $(pwd)/Build/windows/$project.exe $FILENAME
mv $(pwd)/Build/windows/$project_Data $FILENAME
zip -r $FILENAME.zip

echo 'Logs from build'
cat $(pwd)/unity.log


echo "Deploy to Itch"
wget http://dl.itch.ovh/butler/linux-amd64/head/butler
chmod +x butler
touch butler_creds
echo -n $ITCH_API_KEY > butler_creds

./butler push $FILENAME.zip hacktavist/testing-travisci-deployment

echo "Cleaning"

./butler logout -i butler_creds --assume-yes
#rm butler