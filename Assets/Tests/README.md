# Bubble Shooter - Testing Documentation

## Test Coverage

This project now includes automated tests for Unity using the Unity Test Framework.

### Test Structure

- **EditMode Tests** (`Assets/Tests/EditMode/`): Tests that run in the Unity Editor without entering Play mode
- **PlayMode Tests** (`Assets/Tests/PlayMode/`): Tests that run in Play mode to test runtime behavior

### Running Tests

#### In Unity Editor
1. Open Unity Test Runner: `Window > General > Test Runner`
2. Select EditMode or PlayMode tab
3. Click "Run All" to execute tests

#### Via Command Line
```bash
# Run EditMode tests
Unity -runTests -batchmode -projectPath . -testPlatform EditMode -testResults ./test-results.xml

# Run PlayMode tests
Unity -runTests -batchmode -projectPath . -testPlatform PlayMode -testResults ./test-results.xml
```

### CI/CD Pipeline

The project includes a GitHub Actions workflow that:
- Runs EditMode and PlayMode tests automatically on push/PR
- Builds the project for Windows and Android
- Caches Unity Library for faster builds
- Uploads test results and build artifacts

### Test Coverage Areas

- Vector operations and math utilities
- GameObject creation and management
- Bubble movement and physics
- Color validation for bubble matching
- Component lifecycle management

### Adding New Tests

1. Create new test files in appropriate folder (EditMode/PlayMode)
2. Inherit from the `BubbleShooter.Tests` namespace
3. Use `[Test]` attribute for synchronous tests
4. Use `[UnityTest]` attribute with `IEnumerator` for asynchronous tests

### Requirements

- Unity Test Framework package (included by default)
- NUnit Framework (included with Unity Test Framework)
