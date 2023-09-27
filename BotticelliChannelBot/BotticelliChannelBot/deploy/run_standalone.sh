sudo apt-get update && \  sudo apt-get install -y dotnet-sdk-7.0

rm -rf botticelli_channel_bot
git clone https://github.com/devgopher/botticelli_channel_bot.git
pushd botticelli_channel_bot
git checkout develop
git pull
git submodule update --init --remote --recursive

pushd BotticelliChannelBot/BotticelliChannelBot

nohup dotnet run &

echo BOT ID:
cat Data/botId

popd