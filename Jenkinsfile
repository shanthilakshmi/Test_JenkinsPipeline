
pipeline {
  agent any 
  stages {
    stage('Init') {
      steps {
        sh 'rm -rf packges */bin build'
        sh 'mkdir -p build'
        sh 'ls -la'
      }
    }
    stage('Build') {
      steps {
        sh "dotnet /t:build /restore:True"
      }
    }
    stage('Package') {
      steps {
        sh "dotnet /t:pack"
        sh 'cat */obj/*/*.nuspec'              
      }
    }
    stage('Publish NuGet') {
      steps {
          echo 'Deploying'
          sh "dotnet /t:publish -f net472"
      }        
    }
  }
}

def getConfiguration(branchName) {
  def matcher = (branchName =~ /master/)
  if (matcher.matches())
    return "Release"
  
  return "Debug"
}
