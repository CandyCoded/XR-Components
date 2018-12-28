clean:
	rm -rf Library/
	rm -rf Packages/
	rm -rf ProjectSettings/
	rm -f unity.log

deploy:
	git subtree push --prefix Assets/Plugins/XR-Components origin upm
