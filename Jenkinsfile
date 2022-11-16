
pipeline {
  agent any 
  stages {
    stage('Init') {
      steps {
        sh 'sudo rm -rf packges */bin build'
        sh 'sudo mkdir -p build'
        sh 'sudo ls -la'
      }
    }
    stage('Build') {
      steps {
        sh " sudo msbuild /t:build /restore:True"
      }
    }
    stage('Package') {
      steps {
        sh "sudo msbuild /t:pack"
        sh 'sudo cat */obj/*/*.nuspec'              
      }
    }
    stage('Publish NuGet') {
      steps {
          echo 'Deploying'
          sh "sudo msbuild /t:publish -f net472"
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
