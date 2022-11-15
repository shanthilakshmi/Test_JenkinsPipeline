
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
        echo "The library will be build in "
        sh "msbuild /t:build /restore:True"
      }
    }
    stage('Package') {
      steps {
        sh "msbuild /t:pack"
        sh 'cat */obj/*/*.nuspec'              
      }
    }
    stage('Publish NuGet') {
      when {
        branch 'master'
      }
      steps {
        withCredentials([string(credentialsId: 'nuget_token', variable: 'NUGET_TOKEN')]) {
          echo 'Deploying'
          sh "nuget push build/*.nupkg -ApiKey ${NUGET_TOKEN} -SkipDuplicate -Source https://www.nuget.org/api/v2/package"
        }
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
